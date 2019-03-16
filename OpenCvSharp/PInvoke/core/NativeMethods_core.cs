﻿using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        #region Miscellaneous
        [DllImport(DllExtern)]
        public static extern void core_setNumThreads(int nthreads);
        [DllImport(DllExtern)]
        public static extern int core_getNumThreads();
        [DllImport(DllExtern)]
        public static extern int core_getThreadNum();
        [DllImport(DllExtern,  BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern void core_getBuildInformation([MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, int maxLength);
        [DllImport(DllExtern,  BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int core_getBuildInformation_length();

        [DllImport(DllExtern)]
        public static extern long core_getTickCount();
        [DllImport(DllExtern)]
        public static extern double core_getTickFrequency();
        [DllImport(DllExtern)]
        public static extern long core_getCPUTickCount();
        [DllImport(DllExtern)]
        public static extern int core_checkHardwareSupport(int feature);
        [DllImport(DllExtern)]
        public static extern int core_getNumberOfCPUs();
        [DllImport(DllExtern)]
        public static extern IntPtr core_fastMalloc(IntPtr bufSize);
        [DllImport(DllExtern)]
        public static extern void core_fastFree(IntPtr ptr);
        [DllImport(DllExtern)]
        public static extern void core_setUseOptimized(int onoff);
        [DllImport(DllExtern)]
        public static extern int core_useOptimized();

        [DllImport(DllExtern)]
        public static extern IntPtr redirectError(CvErrorCallback errCallback, IntPtr userdata, ref IntPtr prevUserdata);

        [DllImport(DllExtern)]
        public static extern IntPtr core_cvarrToMat(IntPtr arr, int copyData, int allowND, int coiMode);
        [DllImport(DllExtern)]
        public static extern void core_extractImageCOI(IntPtr arr, IntPtr coiimg, int coi);
        [DllImport(DllExtern)]
        public static extern void core_insertImageCOI(IntPtr coiimg, IntPtr arr, int coi);
        #endregion

        #region Array Operations

        [DllImport(DllExtern)]
        public static extern void core_add(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);

        [DllImport(DllExtern)]
        public static extern void core_subtract_InputArray2(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_subtract_InputArrayScalar(IntPtr src1, Scalar src2, IntPtr dst, IntPtr mask, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_subtract_ScalarInputArray(Scalar src1, IntPtr src2, IntPtr dst, IntPtr mask, int dtype);

        [DllImport(DllExtern)]
        public static extern void core_multiply(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_divide1(double scale, IntPtr src2, IntPtr dst, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_divide2(IntPtr src1, IntPtr src2, IntPtr dst, double scale, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_scaleAdd(IntPtr src1, double alpha, IntPtr src2,IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_addWeighted(IntPtr src1, double alpha, IntPtr src2,
            double beta, double gamma, IntPtr dst, int dtype);

        #endregion


        [DllImport(DllExtern)]
        public static extern void core_convertScaleAbs(IntPtr src, IntPtr dst, double alpha, double beta);
        [DllImport(DllExtern)]
        public static extern void core_LUT(IntPtr src, IntPtr lut, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern Scalar core_sum(IntPtr src);
        [DllImport(DllExtern)]
        public static extern int core_countNonZero(IntPtr src);
        [DllImport(DllExtern)]
        public static extern void core_findNonZero(IntPtr src, IntPtr idx);
        [DllImport(DllExtern)]
        public static extern Scalar core_mean(IntPtr src, IntPtr mask);

        [DllImport(DllExtern)]
        public static extern void core_meanStdDev_OutputArray(
            IntPtr src, IntPtr mean, IntPtr stddev, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_meanStdDev_Scalar(
            IntPtr src, out Scalar mean, out Scalar stddev, IntPtr mask);

        [DllImport(DllExtern)]
        public static extern double core_norm1(IntPtr src1, int normType, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern double core_norm2(IntPtr src1, IntPtr src2,
                                               int normType, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_batchDistance(IntPtr src1, IntPtr src2,
                                                     IntPtr dist, int dtype, IntPtr nidx,
                                                     int normType, int k, IntPtr mask,
                                                     int update, int crosscheck);
        [DllImport(DllExtern)]
        public static extern void core_normalize(IntPtr src, IntPtr dst, double alpha, double beta,
                             int normType, int dtype, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_minMaxLoc1(IntPtr src, out double minVal, out double maxVal);
        [DllImport(DllExtern)]
        public static extern void core_minMaxLoc2(IntPtr src, out double minVal, out double maxVal,
            out Point minLoc, out Point maxLoc, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_minMaxIdx1(IntPtr src, out double minVal, out double maxVal);
        [DllImport(DllExtern)]
        public static extern void core_minMaxIdx2(IntPtr src, out double minVal, out double maxVal,
            [MarshalAs(UnmanagedType.LPArray)] int[] minIdx, [MarshalAs(UnmanagedType.LPArray)] int[] maxIdx, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_reduce(IntPtr src, IntPtr dst, int dim, int rtype, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_merge([MarshalAs(UnmanagedType.LPArray)] IntPtr[] mv, uint count, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_split(IntPtr src, out IntPtr mv);
        [DllImport(DllExtern)]
        public static extern void core_mixChannels(IntPtr[] src, uint nsrcs,
            IntPtr[] dst, uint ndsts, int[] fromTo, uint npairs);
        [DllImport(DllExtern)]
        public static extern void core_extractChannel(IntPtr src, IntPtr dst, int coi);
        [DllImport(DllExtern)]
        public static extern void core_insertChannel(IntPtr src, IntPtr dst, int coi);
        [DllImport(DllExtern)]
        public static extern void core_flip(IntPtr src, IntPtr dst, int flipCode);
        [DllImport(DllExtern)]
        public static extern void core_repeat1(IntPtr src, int ny, int nx, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern IntPtr core_repeat2(IntPtr src, int ny, int nx);
        [DllImport(DllExtern)]
        public static extern void core_hconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_hconcat2(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_vconcat1([MarshalAs(UnmanagedType.LPArray)] IntPtr[] src, uint nsrc, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_vconcat2(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_bitwise_and(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_bitwise_or(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_bitwise_xor(IntPtr src1, IntPtr src2, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_bitwise_not(IntPtr src, IntPtr dst, IntPtr mask);
        [DllImport(DllExtern)]
        public static extern void core_absdiff(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_inRange_InputArray(IntPtr src, IntPtr lowerb, IntPtr upperb, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_inRange_Scalar(IntPtr src, Scalar lowerb, Scalar upperb, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_compare(IntPtr src1, IntPtr src2, IntPtr dst, int cmpop);
        [DllImport(DllExtern)]
        public static extern void core_min1(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_max1(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_min_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_min_MatDouble(IntPtr src1, double src2, IntPtr dst);
        [DllImport(DllExtern)] 
        public static extern void core_max_MatMat(IntPtr src1, IntPtr src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_max_MatDouble(IntPtr src1, double src2, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_sqrt(IntPtr src, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_pow_Mat(IntPtr src, double power, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_exp_Mat(IntPtr src, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_log_Mat(IntPtr src, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern float core_cubeRoot(float val);
        [DllImport(DllExtern)]
        public static extern float core_fastAtan2(float y, float x);
        [DllImport(DllExtern)]
        public static extern void core_polarToCart(IntPtr magnitude, IntPtr angle, IntPtr x, IntPtr y, int angleInDegrees);
        [DllImport(DllExtern)]
        public static extern void core_cartToPolar(IntPtr x, IntPtr y, IntPtr magnitude, IntPtr angle, int angleInDegrees);
        [DllImport(DllExtern)]
        public static extern void core_phase(IntPtr x, IntPtr y, IntPtr angle, int angleInDegrees);
        [DllImport(DllExtern)]
        public static extern void core_magnitude_Mat(IntPtr x, IntPtr y, IntPtr magnitude);
        [DllImport(DllExtern)]
        public static extern int core_checkRange(IntPtr a, int quiet, out Point pos, double minVal, double maxVal);
        [DllImport(DllExtern)]
        public static extern void core_patchNaNs(IntPtr a, double val);
        [DllImport(DllExtern)]
        public static extern void core_gemm(IntPtr src1, IntPtr src2, double alpha, IntPtr src3, double gamma, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern void core_mulTransposed(IntPtr src, IntPtr dst, int aTa, IntPtr delta, double scale, int dtype);
        [DllImport(DllExtern)]
        public static extern void core_transpose(IntPtr src, IntPtr dst);
        [DllImport(DllExtern)]
        public static extern void core_transform(IntPtr src, IntPtr dst, IntPtr m);

        [DllImport(DllExtern)]
        public static extern void core_perspectiveTransform(IntPtr src, IntPtr dst, IntPtr m);
        [DllImport(DllExtern)]
        public static extern void core_perspectiveTransform_Mat(IntPtr src, IntPtr dst, IntPtr m);
        [DllImport(DllExtern)]
        public static extern void core_perspectiveTransform_Point2f(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);
        [DllImport(DllExtern)]
        public static extern void core_perspectiveTransform_Point2d(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);
        [DllImport(DllExtern)]
        public static extern void core_perspectiveTransform_Point3f(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);
        [DllImport(DllExtern)]
        public static extern void core_perspectiveTransform_Point3d(IntPtr src, int srcLength, IntPtr dst, int dstLength, IntPtr m);

        [DllImport(DllExtern)]
        public static extern void core_completeSymm(IntPtr mtx, int lowerToUpper);
        [DllImport(DllExtern)]
        public static extern void core_setIdentity(IntPtr mtx, Scalar s);
        [DllImport(DllExtern)]
        public static extern double core_determinant(IntPtr mtx);
        [DllImport(DllExtern)]
        public static extern Scalar core_trace(IntPtr mtx);
        [DllImport(DllExtern)]
        public static extern double core_invert(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern int core_solve(IntPtr src1, IntPtr src2, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern void core_sort(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern void core_sortIdx(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern int core_solveCubic(IntPtr coeffs, IntPtr roots);
        [DllImport(DllExtern)]
        public static extern double core_solvePoly(IntPtr coeffs, IntPtr roots, int maxIters);
        [DllImport(DllExtern)]
        public static extern int core_eigen(IntPtr src, IntPtr eigenvalues, IntPtr eigenvectors);

        [DllImport(DllExtern)]
        public static extern void core_calcCovarMatrix_Mat([MarshalAs(UnmanagedType.LPArray)] IntPtr[] samples, 
            int nsamples, IntPtr covar, IntPtr mean, int flags, int ctype);
        [DllImport(DllExtern)]
        public static extern void core_calcCovarMatrix_InputArray(IntPtr samples, IntPtr covar,
            IntPtr mean, int flags, int ctype);

        [DllImport(DllExtern)]
        public static extern void core_PCACompute(IntPtr data, IntPtr mean, IntPtr eigenvectors, int maxComponents);
        [DllImport(DllExtern)]
        public static extern void core_PCAComputeVar(IntPtr data, IntPtr mean, IntPtr eigenvectors, double retainedVariance);
        [DllImport(DllExtern)]
        public static extern void core_PCAProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);
        [DllImport(DllExtern)]
        public static extern void core_PCABackProject(IntPtr data, IntPtr mean, IntPtr eigenvectors, IntPtr result);

        [DllImport(DllExtern)]
        public static extern void core_SVDecomp(IntPtr src, IntPtr w, IntPtr u, IntPtr vt, int flags);
        [DllImport(DllExtern)]
        public static extern void core_SVBackSubst(IntPtr w, IntPtr u, IntPtr vt, IntPtr rhs, IntPtr dst);

        [DllImport(DllExtern)]
        public static extern double core_Mahalanobis(IntPtr v1, IntPtr v2, IntPtr icovar);
        [DllImport(DllExtern)]
        public static extern void core_dft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);
        [DllImport(DllExtern)]
        public static extern void core_idft(IntPtr src, IntPtr dst, int flags, int nonzeroRows);
        [DllImport(DllExtern)]
        public static extern void core_dct(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern void core_idct(IntPtr src, IntPtr dst, int flags);
        [DllImport(DllExtern)]
        public static extern void core_mulSpectrums(IntPtr a, IntPtr b, IntPtr c, int flags, int conjB);
        [DllImport(DllExtern)]
        public static extern int core_getOptimalDFTSize(int vecsize);
        [DllImport(DllExtern)]
        public static extern double core_kmeans(IntPtr data, int k, IntPtr bestLabels,
            TermCriteria criteria, int attempts, int flags, IntPtr centers);

        [DllImport(DllExtern)]
        public static extern ulong core_theRNG();

        [DllImport(DllExtern)]
        public static extern void core_randu_InputArray(IntPtr dst, IntPtr low, IntPtr high);
        [DllImport(DllExtern)]
        public static extern void core_randu_Scalar(IntPtr dst, Scalar low, Scalar high);

        [DllImport(DllExtern)]
        public static extern void core_randn_InputArray(IntPtr dst, IntPtr mean, IntPtr stddev);
        [DllImport(DllExtern)]
        public static extern void core_randn_Scalar(IntPtr dst, Scalar mean, Scalar stddev);

        [DllImport(DllExtern)]
        public static extern void core_randShuffle(IntPtr dst, double iterFactor, ref ulong rng);
        [DllImport(DllExtern)]
        public static extern void core_randShuffle(IntPtr dst, double iterFactor, IntPtr rng);
    }
}