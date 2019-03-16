﻿using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {

        #region Inpainting

        [DllImport(DllExtern)]
        public static extern void xphoto_inpaint(IntPtr prt, IntPtr src, IntPtr dst, int algorithm);

        #endregion

        #region WhiteBalance

        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_applyChannelGains(IntPtr src, IntPtr dst, float gainB, float gainG, float gainR);

        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_createGrayworldWB();

        [DllImport(DllExtern)]
        public static extern void xphoto_Ptr_GrayworldWB_delete(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_Ptr_GrayworldWB_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern void xphoto_GrayworldWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern)]
        public static extern float xphoto_GrayworldWB_SaturationThreshold_get(IntPtr ptr);

        [DllImport(DllExtern)]
        public static extern void xphoto_GrayworldWB_SaturationThreshold_set(IntPtr ptr, float val);


        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_createLearningBasedWB(string trackerType);

        [DllImport(DllExtern)]
        public static extern void xphoto_Ptr_LearningBasedWB_delete(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_Ptr_LearningBasedWB_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern void xphoto_LearningBasedWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern)]
        public static extern void xphoto_LearningBasedWB_extractSimpleFeatures(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern)]
        public static extern void xphoto_LearningBasedWB_HistBinNum_set(IntPtr prt, int value);

        [DllImport(DllExtern)]
        public static extern void xphoto_LearningBasedWB_RangeMaxVal_set(IntPtr prt, int value);

        [DllImport(DllExtern)]
        public static extern float xphoto_LearningBasedWB_SaturationThreshold_set(IntPtr prt, float value);

        [DllImport(DllExtern)]
        public static extern int xphoto_LearningBasedWB_HistBinNum_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern int xphoto_LearningBasedWB_RangeMaxVal_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern float xphoto_LearningBasedWB_SaturationThreshold_get(IntPtr prt);


        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_createSimpleWB();

        [DllImport(DllExtern)]
        public static extern void xphoto_Ptr_SimpleWB_delete(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern IntPtr xphoto_Ptr_SimpleWB_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern void xphoto_SimpleWB_balanceWhite(IntPtr prt, IntPtr src, IntPtr dst);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_InputMax_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_InputMax_set(IntPtr prt, float value);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_InputMin_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_InputMin_set(IntPtr prt, float value);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_OutputMax_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_OutputMax_set(IntPtr prt, float value);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_OutputMin_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_OutputMin_set(IntPtr prt, float value);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_P_get(IntPtr prt);

        [DllImport(DllExtern)]
        public static extern float xphoto_SimpleWB_P_set(IntPtr prt, float value);

        #endregion

    }
}