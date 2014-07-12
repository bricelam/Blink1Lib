using System;
using System.Runtime.InteropServices;

namespace Bricelam.Blink1Lib.Interop
{
    // TODO: Cached devices, Mk1 support
    internal class NativeMethods
    {
        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_enumerate();

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern blink1_device blink1_open();

        [DllImport(
            "blink1-lib",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Ansi,
            ExactSpelling = true)]
        public static extern blink1_device blink1_openBySerial(string serial);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern blink1_device blink1_openById(long id);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void blink1_close(IntPtr dev);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_getVersion(blink1_device dev);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_fadeToRGB(blink1_device dev, ushort fadeMillis, byte r, byte g, byte b);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_fadeToRGBN(
            blink1_device dev,
            ushort fadeMillis,
            byte r,
            byte g,
            byte b,
            byte n);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_setRGB(blink1_device dev, byte r, byte g, byte b);

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_readRGB(
            blink1_device dev,
            out ushort fadeMillis,
            out byte r,
            out byte g,
            out byte b,
            byte ledn);

        [DllImport(
            "blink1-lib",
            EntryPoint = "blink1_getSerialForDev",
            CallingConvention = CallingConvention.Cdecl,
            ExactSpelling = true)]
        private static extern IntPtr blink1_getSerialForDev_raw(blink1_device dev);

        public static string blink1_getSerialForDev(blink1_device dev)
        {
            return Marshal.PtrToStringAnsi(blink1_getSerialForDev_raw(dev));
        }

        [DllImport("blink1-lib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int blink1_isMk2(blink1_device dev);
    }
}
