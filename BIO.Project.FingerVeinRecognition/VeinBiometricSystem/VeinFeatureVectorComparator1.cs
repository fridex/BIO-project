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
            Image<Gray, byte> img_e = extracted.img.Clone();
            Image<Gray, byte> img_t = templated.img.Clone();
            double sum = 0.0;

            int width_size = img_e.Width < img_t.Width ? img_t.Width : img_e.Width;
            int height_size = img_e.Height < img_t.Height ? img_t.Height : img_e.Height;

            img_e.Resize(width_size, height_size, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            img_t.Resize(width_size, height_size, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

            for (int i = 0; i < img_e.Height; i++)
            {
                for (int j = 0; j < img_e.Width; j++)
                {
                    sum += img_e.Data[i, j, 0] + img_t.Data[i, j, 0];
                }
            }

            return new MatchingScore(sum);
        }

        #endregion
    }

       
}
