using System.Runtime.InteropServices;

namespace YoloWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BboxContainer
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public BoundingBox[] candidates;
    }
}
