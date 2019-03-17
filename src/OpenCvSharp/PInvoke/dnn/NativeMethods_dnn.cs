﻿using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    // ReSharper disable InconsistentNaming

    static partial class NativeMethods
    {
        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromDarknet(
            [MarshalAs(UnmanagedType.LPStr)] string cfgFile, [MarshalAs(UnmanagedType.LPStr)] string darknetModel);

        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromCaffe(
            [MarshalAs(UnmanagedType.LPStr)] string prototxt, [MarshalAs(UnmanagedType.LPStr)] string caffeModel);

        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromTensorflow(
            [MarshalAs(UnmanagedType.LPStr)] string model, [MarshalAs(UnmanagedType.LPStr)] string config);

        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readNetFromTorch([MarshalAs(UnmanagedType.LPStr)] string model, int isBinary);


        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_readTorchBlob([MarshalAs(UnmanagedType.LPStr)] string filename, int isBinary);

        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_blobFromImage(
            IntPtr image, double scalefactor, Size size, Scalar mean, int swapRB, int crop);

        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern IntPtr dnn_blobFromImages(
            IntPtr[] images, int imagesLength, double scalefactor, Size size, Scalar mean, int swapRB, int crop);

        [DllImport(DllExtern, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void dnn_shrinkCaffeModel(
            [MarshalAs(UnmanagedType.LPStr)] string src, [MarshalAs(UnmanagedType.LPStr)] string dst);

    }
}
