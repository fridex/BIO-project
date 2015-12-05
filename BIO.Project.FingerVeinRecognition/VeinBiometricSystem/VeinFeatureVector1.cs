using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem
{
    [Serializable]
    public class VeinFeatureVector1 : IFeatureVector
    {
        public List<double> intensity;
        public VeinFeatureVector1()
        {
        }
    }
}
