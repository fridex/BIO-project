using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIO.Framework.Core.FeatureVector;
using BIO.Framework.Extensions.Emgu.InputData;
using Emgu.CV;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem
{
    [Serializable]
    public class VeinFeatureVector1 : IFeatureVector
    {
        public Image<Emgu.CV.Structure.Gray, byte> img;
        public VeinFeatureVector1()
        {

        }
    }
}
