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
    class VeinFeatureVectorExtractor1 : IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector1>
    {
        public VeinFeatureVector1 extractFeatureVector(EmguGrayImageInputData input)
        {
            VeinFeatureVector1 fv = new VeinFeatureVector1();
            for (int i = 0; i < input.Image.Height; i++)
            {
                for (int j = 0; j < input.Image.Width; j++)
                {
                    fv.intensity.Add(input.Image.Bytes[i * input.Image.Height + j]);
                }
            }
            return fv;
        }
    }
}
