using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Core;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Emgu.FeatureVector;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using BIO.Framework.Core.FeatureVector;
using BIO.Project.FingerVeinRecognition.VeinBiometricSystem;

namespace BIO.Project.FingerVeinRecognition
{
    class VeinFeatureVectorExtractor : IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector> {
        #region IFeatureVectorExtractor<EmguGrayImageInputData,EmguGrayImageFeatureVector> Members

        public VeinFeatureVector extractFeatureVector(EmguGrayImageInputData input) {
            //TODO zmenseni upravit podle pdf
            Image<Gray, byte> smaller = input.Image.Resize(0.15, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

           
            EmguGrayImageFeatureVector fv = new EmguGrayImageFeatureVector(new System.Drawing.Size(smaller.Width, smaller.Height));

            fv.FeatureVector = smaller.Copy();

            VeinFeatureVector featureVector = new VeinFeatureVector();

            //TODO nejak to extrahovat :)

            return featureVector;
        }

        #endregion
    }
}
