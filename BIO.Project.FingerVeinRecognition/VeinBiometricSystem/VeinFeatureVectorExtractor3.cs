﻿using System;
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
    class VeinFeatureVectorExtractor3 : IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector3>
    {
        public VeinFeatureVector3 extractFeatureVector(EmguGrayImageInputData input)
        {
            Image<Gray, byte> smaller = input.Image.Resize(0.15, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);


            EmguGrayImageFeatureVector im = new EmguGrayImageFeatureVector(new System.Drawing.Size(smaller.Width, smaller.Height));

            VeinFeatureVector3 fv = new VeinFeatureVector3();
            fv.image = smaller.Copy();
            
            return fv;
        }
    }
}
