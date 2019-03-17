﻿using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        // ReSharper disable InconsistentNaming

        // BRISK
        [DllImport(DllExtern)]
        public static extern IntPtr features2d_BRISK_create1(int thresh, int octaves, float patternScale);
        [DllImport(DllExtern)]
        public static extern IntPtr features2d_BRISK_create2(
            float[] radiusList, int radiusListLength, int[] numberList, int numberListLength,
            float dMax, float dMin,
            int[] indexChange, int indexChangeLength);
        
        [DllImport(DllExtern)]
        public static extern void features2d_Ptr_BRISK_delete(IntPtr ptr);
        [DllImport(DllExtern)]
        public static extern IntPtr features2d_Ptr_BRISK_get(IntPtr ptr);
    }
}