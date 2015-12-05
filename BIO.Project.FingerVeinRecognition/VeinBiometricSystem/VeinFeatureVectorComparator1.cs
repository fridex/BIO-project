using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.UI;
using BIO.Framework.Core;
using BIO.Project.FingerVeinRecognition.VeinBiometricSystem;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem {
    
    class VeinFeatureVectorComparator1 : IFeatureVectorComparator<VeinFeatureVector1, VeinFeatureVector1> {

        #region IFeatureVectorComparator<VeinFeatureVector,VeinFeatureVector> Members

        public MatchingScore computeMatchingScore(VeinFeatureVector1 extracted, VeinFeatureVector1 templated) {
            double sum = 0.0;
            
            //TODO vymyselet zpusob vypoctu skore

            return new MatchingScore(sum);
        }

        #endregion
    }

       
}
