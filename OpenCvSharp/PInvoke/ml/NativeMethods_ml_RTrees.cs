﻿using System;
using System.Runtime.InteropServices;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [DllImport(DllExtern)]
        public static extern int ml_RTrees_getCalculateVarImportance(IntPtr obj);
        [DllImport(DllExtern)]
        public static extern void ml_RTrees_setCalculateVarImportance(IntPtr obj, int val);
        
        [DllImport(DllExtern)]
        public static extern int ml_RTrees_getActiveVarCount(IntPtr obj);
        [DllImport(DllExtern)]
        public static extern void ml_RTrees_setActiveVarCount(IntPtr obj, int val);
        
        [DllImport(DllExtern)]
        public static extern TermCriteria ml_RTrees_getTermCriteria(IntPtr obj);
        [DllImport(DllExtern)]
        public static extern void ml_RTrees_setTermCriteria(IntPtr obj, TermCriteria val);
        
        [DllImport(DllExtern)]
        public static extern IntPtr ml_RTrees_getVarImportance(IntPtr obj);
        
        [DllImport(DllExtern)]
        public static extern IntPtr ml_RTrees_create();
        
        [DllImport(DllExtern)]
        public static extern void ml_Ptr_RTrees_delete(IntPtr obj);
        
        [DllImport(DllExtern)]
        public static extern IntPtr ml_Ptr_RTrees_get(IntPtr obj);

        [DllImport(DllExtern)]
        public static extern IntPtr ml_RTrees_load(string filePath);

        [DllImport(DllExtern)]
        public static extern IntPtr ml_RTrees_loadFromString(string strModel);
    }
}