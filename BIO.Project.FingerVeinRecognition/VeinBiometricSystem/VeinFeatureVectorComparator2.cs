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
    
    class VeinFeatureVectorComparator2 : IFeatureVectorComparator<VeinFeatureVector2, VeinFeatureVector2> {

        #region IFeatureVectorComparator<VeinFeatureVector,VeinFeatureVector> Members

        public MatchingScore computeMatchingScore(VeinFeatureVector2 extracted, VeinFeatureVector2 templated) {
            //TODO vymyselet zpusob vypoctu skore
            Image<Gray, byte> img_e = extracted.image.Clone();
            Image<Gray, byte> img_t = templated.image.Clone();
            double sum = 0.0;

            int width_size = img_e.Width < img_t.Width ? img_t.Width : img_e.Width;
            int height_size = img_e.Height < img_t.Height ? img_t.Height : img_e.Height;

            img_e.Resize(width_size, height_size, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            img_t.Resize(width_size, height_size, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);

            int inc = 1;
            int sum_img1 = 0, sum_img2 = 0;
            byte white = 255;
            bool vein = false;
            for (int i = 30; i < img_e.Height - 30; i += inc)
            {
                vein = false;
                for (int j = 3; j < img_e.Width-3; j++)
                {
                    if (vein == false)
                    {
                        if (img_e.Data[i, j, 0] == white)
                        {
                            sum_img1++;
                            j += 5;
                            vein = true;
                        }
                    }
                    else if (img_e.Data[i, j, 0] != white)
                    {
                        vein = false;
                    }
                }
                vein = false;
                for (int j = 0; j < img_e.Width; j++)
                {
                    if (vein == false)
                    {
                        if (img_t.Data[i, j, 0] == white)
                        {
                            sum_img2++;
                            j += 5;
                            vein = true;
                        }
                    }
                    else if (img_t.Data[i, j, 0] != white)
                    {
                        vein = false;
                    }
                }
                if (sum_img1 == sum_img2)
                    sum++;
                sum_img1 = 0;
                sum_img2 = 0;
            }

            return new MatchingScore(sum);
        }

        #endregion
    }

       
}
