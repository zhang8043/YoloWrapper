using System;
using System.Runtime.InteropServices;

namespace YoloWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BoundingBox
    {
        public UInt32 x, y, w, h;
        public float prob;
        public UInt32 obj_id;
        public UInt32 track_id;
        public UInt32 frames_counter;
        public float x_3d, y_3d, z_3d;
    }
}
