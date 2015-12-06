using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIO.Framework.Core.FeatureVector;
using Emgu.CV;
using Emgu.CV.Structure;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem
{
    [Serializable]
    public class VeinFeatureVector2 : IFeatureVector
    {
        public Image<Gray, byte> image;

        public VeinFeatureVector2()
        {
        }
    }
}
