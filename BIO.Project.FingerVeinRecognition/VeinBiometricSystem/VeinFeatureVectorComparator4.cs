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
    
    class VeinFeatureVectorComparator4 : IFeatureVectorComparator<VeinFeatureVector4, VeinFeatureVector4> {

        #region IFeatureVectorComparator<VeinFeatureVector,VeinFeatureVector> Members

        public MatchingScore computeMatchingScore(VeinFeatureVector4 extracted, VeinFeatureVector4 templated) {
            Image<Gray, byte> m1 = extracted.image.Clone();

            m1 = m1.AbsDiff(templated.image);

            double sum = 0;
            byte[,,] data = m1.Data;


            for (int i = m1.Rows - 1; i >= 0; i--)
            {
                for (int j = m1.Cols - 1; j >= 0; j--)
                {
                    sum += data[i, j, 0];
                }
            }

            return new MatchingScore(sum);
        }

        #endregion
    }

       
}
