﻿
using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern)]
        public static extern IntPtr face_FisherFaceRecognizer_create(int numComponents, double threshold);

        [DllImport(DllExtern)]
        public static extern IntPtr face_Ptr_FisherFaceRecognizer_get(IntPtr obj);

        [DllImport(DllExtern)]
        public static extern void face_Ptr_FisherFaceRecognizer_delete(IntPtr obj);
    }
}