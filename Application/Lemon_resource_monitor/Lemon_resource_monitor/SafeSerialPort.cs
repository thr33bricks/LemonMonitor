using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lemon_resource_monitor
{
    public class SafeSerialPort : SerialPort
    {
        private Stream theBaseStream;

        public SafeSerialPort(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
                                                      : base(portName, baudRate, parity, dataBits, stopBits)
        { }

        public new void Open()
        {
            try
            {
                base.Open();
                theBaseStream = BaseStream;
                GC.SuppressFinalize(BaseStream);
            }
            catch { }
        }

        public new void Dispose()
        {
            Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (base.Container != null))
                base.Container.Dispose();
            try
            {
                if (theBaseStream.CanRead)
                {
                    theBaseStream.Close();
                    GC.ReRegisterForFinalize(theBaseStream);
                }
            }
            catch
            {
                // ignore exception - bug with USB - serial adapters.
            }
            base.Dispose(disposing);
        }
    }
}
