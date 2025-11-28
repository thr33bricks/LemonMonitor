using PresentMonFps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Lemon_resource_monitor
{
    public class FixedSizeConcurrentQueue<T>
    {
        private readonly ConcurrentQueue<T> _queue = new ConcurrentQueue<T>();
        private readonly int _maxSize;

        public FixedSizeConcurrentQueue(int maxSize)
        {
            _maxSize = maxSize;
        }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);

            // remove extra items (approximate trimming)
            while (_queue.Count > _maxSize)
                _queue.TryDequeue(out _);
        }

        public T[] ToArray() => _queue.ToArray();

        public int Count => _queue.Count;
    }
    class FPSInfo
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        static private Task fpsTask;
        static private readonly object fpsLock = new object();

        static uint currentPid = 0;
        static CancellationTokenSource fpsCts;
        const int maxFpsVals = 64;
        
        static public List<float> fpsVals = new List<float>();
        static public volatile float FPS = 0;
        static public volatile float avgFPS = 0.0F;
        static public volatile float onePercentLow = 0.0F;

        static FixedSizeConcurrentQueue<float>fpsQueue = new FixedSizeConcurrentQueue<float>(3000);

        public FPSInfo()
        {
            if (!FpsInspector.IsAvailable || !FpsInspector.IsRunAsAdmin())
            {
                throw new NotSupportedException();
            }
        }

        public static void InitFPS()
        {
            fpsVals = new List<float>();
            fpsQueue = new FixedSizeConcurrentQueue<float>(1000);
            FPS = 0;
            avgFPS = 0.0F;
            onePercentLow = 0.0F;

            UpdateFPS();
        }

        public void StopFPS()
        {
            FpsInspector.StopTraceSession();
            fpsCts?.Cancel();
            fpsCts?.Dispose();
        }

        static public void UpdateFPS()
        {
            IntPtr hwnd = GetForegroundWindow();
            GetWindowThreadProcessId(hwnd, out uint processId);

            if (currentPid != processId){
                //fpsCts?.Cancel();
                //fpsCts?.Dispose();

                currentPid = processId;
                StartFPS(processId);
            }

            CalculateFPS();
        }

        static private void CalculateFPS()
        {
            if (fpsVals.Count == maxFpsVals)
                fpsVals.RemoveAt(0);
            fpsVals.Add(FPS);

            float sum = 0.0F;
            foreach (var item in fpsVals)
                sum += item;

            avgFPS = fpsVals.Any() ? (sum / fpsVals.Count) : 0;
            onePercentLow = CalculateOnePercentLow();
        }

        static float CalculateOnePercentLow()
        {
            float[] fpsSamplesArr = fpsQueue.ToArray();
            if (fpsSamplesArr.Length == 0)
                return 0f;

            var sorted = fpsSamplesArr.OrderBy(f => f).ToList();
            int count = Math.Max((int)(sorted.Count * 0.01), 1);
            return sorted.Take(count).Average();
        }

        static public byte[] getFPSbarsS1()
        {
            byte[] fpsBars = new byte[32];
            for (int i = 0; i < 32; i++)
                fpsBars[i] = 0x11;
            float maxFPS = fpsVals.DefaultIfEmpty(0).Max();

            if (maxFPS < 2)
                return fpsBars;

            int startNdx = (fpsVals.Count >= 64) ? (fpsVals.Count - 64) : 0;
            int even = fpsVals.Count % 2;
            for (int i = startNdx; i < fpsVals.Count - 1 + even; ++i)
            {
                int fpsBarOffset = (fpsVals.Count >= 64) ? 0 : 64 - fpsVals.Count;

                // Calculate pixel height for each bar (min:1, max:15)
                byte pixelBar1 = 1;
                if (i-even >= 0)
                    pixelBar1 = Math.Max((byte)1, (byte)((fpsVals[i - even] / maxFPS) * 15.0F + 0.5F));
                byte pixelBar2 = Math.Max((byte)1, (byte)((fpsVals[i+1 - even] / maxFPS) * 15.0F + 0.5F));
                fpsBars[(fpsBarOffset + i) / 2] = (byte)(((pixelBar1 & 0x0F) << 4) | (pixelBar2 & 0x0F));
            }

            return fpsBars;
        }

        static private void StartFPS(uint pid)
        {
            lock (fpsLock)
            {
                currentPid = pid;

                // Cancel previous instance
                fpsCts?.Cancel();
                fpsCts?.Dispose();
                fpsCts = new CancellationTokenSource();
                var token = fpsCts.Token;

                fpsTask = Task.Run(async () =>
                {
                    try
                    {
                        await FpsInspector.StartForeverAsync(new FpsRequest(pid) { PeriodMillisecond = 10 }, result =>
                        {
                            float fps = (float)result.Fps;
                            FPS = fps;
                            fpsQueue.Enqueue(fps);
                        }, token);
                    }
                    catch (OperationCanceledException)
                    {
                        // normal during cancellation
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        FPS = 0;
                    }
                });
            }
        }
    }
}
