using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem
{
    [Serializable]
    public class VeinFeatureVector3 : IFeatureVector
    {
        public List<Minutiae> minutiae;

        public VeinFeatureVector3()
        {
            throw new NotImplementedException();
        }
    }
}
