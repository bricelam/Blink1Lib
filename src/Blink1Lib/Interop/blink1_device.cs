using System;
using System.Runtime.InteropServices;

namespace Bricelam.Blink1Lib.Interop
{
    internal class blink1_device : SafeHandle
    {
        public blink1_device()
            : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.blink1_close(handle);
            handle = IntPtr.Zero;

            return true;
        }
    }
}
