using System;
using System.Diagnostics;
using Bricelam.Blink1Lib.Interop;

namespace Bricelam.Blink1Lib
{
    // TODO: Errors
    public class Blink1Mk2 : IDisposable
    {
        private readonly blink1_device _dev;

        public Blink1Mk2()
        {
            _dev = NativeMethods.blink1_open();
            Debug.Assert(!_dev.IsInvalid, "_dev is invalid.");

            var isMk2 = NativeMethods.blink1_isMk2(_dev) != 0;
            Debug.Assert(isMk2, "Device isn't a mk2.");
        }

        public Blink1Mk2(string serial)
        {
            _dev = NativeMethods.blink1_openBySerial(serial);
            Debug.Assert(!_dev.IsInvalid, "_dev is invalid.");

            var isMk2 = NativeMethods.blink1_isMk2(_dev) != 0;
            Debug.Assert(isMk2, "Device isn't a mk2.");
        }

        public Blink1Mk2(long id)
        {
            _dev = NativeMethods.blink1_openById(id);
            Debug.Assert(!_dev.IsInvalid, "_dev is invalid.");

            var isMk2 = NativeMethods.blink1_isMk2(_dev) != 0;
            Debug.Assert(isMk2, "Device isn't a mk2.");
        }

        public static int Devices
        {
            get { return NativeMethods.blink1_enumerate(); }
        }

        public int Version
        {
            get { return NativeMethods.blink1_getVersion(_dev); }
        }

        public string Serial
        {
            get { return NativeMethods.blink1_getSerialForDev(_dev); }
        }

        public void FadeTo(int milliseconds, byte r, byte g, byte b)
        {
            var rc = NativeMethods.blink1_fadeToRGB(_dev, (ushort)milliseconds, r, g, b);
            Debug.Assert(rc != -1, "result is -1.");
        }

        public void FadeTo(int milliseconds, byte r, byte g, byte b, Blink1Led led)
        {
            var rc = NativeMethods.blink1_fadeToRGBN(_dev, (ushort)milliseconds, r, g, b, led);
            Debug.Assert(rc != -1, "result is -1.");
        }

        public void SetColor(byte r, byte g, byte b)
        {
            var rc = NativeMethods.blink1_setRGB(_dev, r, g, b);
            Debug.Assert(rc != -1, "result is -1.");
        }

        public void GetColor(out byte r, out byte g, out byte b, Blink1Led led)
        {
            ushort fadeMillis;

            var rc = NativeMethods.blink1_readRGB(_dev, out fadeMillis, out r, out g, out b, led);
            Debug.Assert(rc != -1, "result is -1.");
        }

        public void Dispose()
        {
            _dev.Dispose();
        }
    }
}
