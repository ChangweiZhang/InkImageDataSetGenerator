using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCvSharp.Util;

namespace OpenCvSharp.Dnn
{
    /// <inheritdoc />
    /// <summary>
    /// This class allows to create and manipulate comprehensive artificial neural networks.
    /// </summary>
    /// <remarks>
    /// Neural network is presented as directed acyclic graph(DAG), where vertices are Layer instances,
    /// and edges specify relationships between layers inputs and outputs.
    /// 
    /// Each network layer has unique integer id and unique string name inside its network.
    /// LayerId can store either layer name or layer id.
    /// This class supports reference counting of its instances, i.e.copies point to the same instance.
    /// </remarks>
    public class Net : DisposableCvObject
    {
        #region Init & Disposal

        /// <inheritdoc />
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Net()
        {
            ptr = NativeMethods.dnn_Net_new();
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected Net(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// </summary>
        protected override void DisposeUnmanaged()
        {
            NativeMethods.dnn_Net_delete(ptr);
            base.DisposeUnmanaged();
        }

        /// <summary>
        /// Reads a network model stored in Darknet (https://pjreddie.com/darknet/) model files.
        /// </summary>
        /// <param name="cfgFile">path to the .cfg file with text description of the network architecture.</param>
        /// <param name="darknetModel">path to the .weights file with learned network.</param>
        /// <returns>Network object that ready to do forward, throw an exception in failure cases.</returns>
        /// <remarks>This is shortcut consisting from DarknetImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromDarknet(string cfgFile, string darknetModel = null)
        {
            if (cfgFile == null)
                throw new ArgumentNullException(nameof(cfgFile));

            IntPtr ptr = NativeMethods.dnn_readNetFromDarknet(cfgFile, darknetModel);
            return new Net(ptr);
        }

        /// <summary>
        /// Reads a network model stored in Caffe model files.
        /// </summary>
        /// <param name="prototxt"></param>
        /// <param name="caffeModel"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createCaffeImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromCaffe(string prototxt, string caffeModel = null)
        {
            if (prototxt == null)
                throw new ArgumentNullException(nameof(prototxt));

            IntPtr ptr = NativeMethods.dnn_readNetFromCaffe(prototxt, caffeModel);
            return new Net(ptr);
        }

        /// <summary>
        /// Reads a network model stored in Tensorflow model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTensorflowImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTensorflow(string model, string config = null)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IntPtr ptr = NativeMethods.dnn_readNetFromTensorflow(model, config);
            return new Net(ptr);
        }

        /// <summary>
        /// Reads a network model stored in Torch model file.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isBinary"></param>
        /// <returns></returns>
        /// <remarks>This is shortcut consisting from createTorchImporter and Net::populateNet calls.</remarks>
        public static Net ReadNetFromTorch(string model, bool isBinary = true)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            IntPtr ptr = NativeMethods.dnn_readNetFromTorch(model, isBinary ? 1 : 0);
            return new Net(ptr);
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Returns true if there are no layers in the network. 
        /// </summary>
        /// <returns></returns>
        public bool Empty()
        {
            var ret = NativeMethods.dnn_Net_empty(ptr);
            GC.KeepAlive(this);
            return ret != 0;
        }

        /// <summary>
        /// Converts string name of the layer to the integer identifier.
        /// </summary>
        /// <param name="layer"></param>
        /// <returns>id of the layer, or -1 if the layer wasn't found.</returns>
        public int GetLayerId(string layer)
        {
            if (layer == null)
                throw new ArgumentNullException(nameof(layer));

            var ret = NativeMethods.dnn_Net_getLayerId(ptr, layer);
            GC.KeepAlive(this);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string[] GetLayerNames()
        {
            using (var namesVec = new VectorOfCvString())
            {
                NativeMethods.dnn_Net_getLayerNames(ptr, namesVec.CvPtr);
                GC.KeepAlive(this);
                return namesVec.ToArray();
            }
        }

        /// <summary>
        /// Connects output of the first layer to input of the second layer.
        /// </summary>
        /// <param name="outPin">descriptor of the first layer output.</param>
        /// <param name="inpPin">descriptor of the second layer input.</param>
        public void Connect(string outPin, string inpPin)
        {
            if (outPin == null)
                throw new ArgumentNullException(nameof(outPin));
            if (inpPin == null)
                throw new ArgumentNullException(nameof(inpPin));

            NativeMethods.dnn_Net_connect1(ptr, outPin, inpPin);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Connects #@p outNum output of the first layer to #@p inNum input of the second layer.
        /// </summary>
        /// <param name="outLayerId">identifier of the first layer</param>
        /// <param name="outNum">identifier of the second layer</param>
        /// <param name="inpLayerId">number of the first layer output</param>
        /// <param name="inpNum">number of the second layer input</param>
        public void Connect(int outLayerId, int outNum, int inpLayerId, int inpNum)
        {
            NativeMethods.dnn_Net_connect2(ptr, outLayerId, outNum, inpLayerId, inpNum);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Sets outputs names of the network input pseudo layer.
        /// </summary>
        /// <param name="inputBlobNames"></param>
        /// <remarks>
        /// * Each net always has special own the network input pseudo layer with id=0.
        /// * This layer stores the user blobs only and don't make any computations.
        /// * In fact, this layer provides the only way to pass user data into the network.
        /// * As any other layer, this layer can label its outputs and this function provides an easy way to do this.
        /// </remarks>
        public void SetInputsNames(IEnumerable<string> inputBlobNames)
        {
            if (inputBlobNames == null)
                throw new ArgumentNullException(nameof(inputBlobNames));

            var inputBlobNamesArray = EnumerableEx.ToArray(inputBlobNames);
            NativeMethods.dnn_Net_setInputsNames(ptr, inputBlobNamesArray, inputBlobNamesArray.Length);
            GC.KeepAlive(this);
        }

        /// <summary>
        /// Runs forward pass to compute output of layer with name @p outputName.
        /// By default runs forward pass for the whole network.
        /// </summary>
        /// <param name="outputName">name for layer which output is needed to get</param>
        /// <returns>blob for first output of specified layer.</returns>
        public Mat Forward(string outputName = null)
        {
            IntPtr ret = NativeMethods.dnn_Net_forward1(ptr, outputName);
            GC.KeepAlive(this);
            return new Mat(ret);
        }

        /// <summary>
        /// Runs forward pass to compute output of layer with name @p outputName.
        /// </summary>
        /// <param name="outputBlobs">contains all output blobs for specified layer.</param>
        /// <param name="outputName">name for layer which output is needed to get. 
        /// If outputName is empty, runs forward pass for the whole network.</param>
        public void Forward(IEnumerable<Mat> outputBlobs, string outputName = null)
        {
            if (outputBlobs == null)
                throw new ArgumentNullException(nameof(outputBlobs));

            var outputBlobsPtrs = EnumerableEx.SelectPtrs(outputBlobs);
            NativeMethods.dnn_Net_forward2(ptr, outputBlobsPtrs, outputBlobsPtrs.Length, outputName);

            GC.KeepAlive(this);
        }

        /// <summary>
        /// Runs forward pass to compute outputs of layers listed in @p outBlobNames.
        /// </summary>
        /// <param name="outputBlobs">contains blobs for first outputs of specified layers.</param>
        /// <param name="outBlobNames">names for layers which outputs are needed to get</param>
        public void Forward(IEnumerable<Mat> outputBlobs, IEnumerable<string> outBlobNames)
        {
            if (outputBlobs == null)
                throw new ArgumentNullException(nameof(outputBlobs));
            if (outBlobNames == null)
                throw new ArgumentNullException(nameof(outBlobNames));

            var outputBlobsPtrs = EnumerableEx.SelectPtrs(outputBlobs);
            var outBlobNamesArray = EnumerableEx.ToArray(outBlobNames);
            NativeMethods.dnn_Net_forward3(ptr, outputBlobsPtrs, outputBlobsPtrs.Length, outBlobNamesArray, outBlobNamesArray.Length);

            GC.KeepAlive(this);
        }

        /// <summary>
        /// Sets the new value for the layer output blob
        /// </summary>
        /// <param name="blob">new blob.</param>
        /// <param name="name">descriptor of the updating layer output blob.</param>
        /// <remarks>
        /// connect(String, String) to know format of the descriptor.
        /// If updating blob is not empty then @p blob must have the same shape, 
        /// because network reshaping is not implemented yet.
        /// </remarks>
        public void SetInput(Mat blob, string name = "")
        {
            if (blob == null)
                throw new ArgumentNullException(nameof(blob));

            NativeMethods.dnn_Net_setInput(ptr, blob.CvPtr, name);
            GC.KeepAlive(this);
        }

        #endregion
    }
}