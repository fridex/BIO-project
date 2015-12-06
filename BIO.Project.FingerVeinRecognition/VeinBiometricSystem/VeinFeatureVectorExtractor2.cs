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
using Emgu.CV.CvEnum;
using System.IO;

namespace BIO.Project.FingerVeinRecognition
{
    class VeinFeatureVectorExtractor2 : IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector2> {
        #region IFeatureVectorExtractor<EmguGrayImageInputData,EmguGrayImageFeatureVector> Members

        int[] neighbours = new int[18] { -1,-1,-1,0,-1,1,0,1,1,1,1,0,1,-1,0,-1,-1,-1 };

        public VeinFeatureVector2 extractFeatureVector(EmguGrayImageInputData input) {
            Image<Gray, byte> smaller;
            if (input.Image.Width > 300)
            {
                smaller = input.Image.Resize(300.0 / input.Image.Width, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }
            else
            {
                smaller = input.Image.Resize(1.0, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }

            VeinFeatureVector2 fv = new VeinFeatureVector2();

            //CvInvoke.cvShowImage("puvodni obrazek", smaller);
            
            Image<Gray, byte> _temp1 = smaller.SmoothGaussian(5);
            Image<Gray, byte> _temp2 = smaller.SmoothMedian(5);            
            _temp2 = _temp2.ThresholdAdaptive(new Gray(255), Emgu.CV.CvEnum.ADAPTIVE_THRESHOLD_TYPE.CV_ADAPTIVE_THRESH_MEAN_C, Emgu.CV.CvEnum.THRESH.CV_THRESH_BINARY, 59, new Gray(0));

            //CvInvoke.cvShowImage("po thresholdingu", _temp2)

            fv.image = _temp2.CopyBlank();
            Image<Gray, byte> mask = _temp2.CopyBlank();

            Contour<System.Drawing.Point> largestContour = null;
            double largestarea = 0;

            for (var contours = _temp2.FindContours(CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                RETR_TYPE.CV_RETR_EXTERNAL); contours != null; contours = contours.HNext)
            {
                if (contours.Area > largestarea)
                {
                    largestarea = contours.Area;
                    largestContour = contours;
                    _temp2.Draw(contours, new Gray(255), -1);
                }
            }
            
            _temp1.Draw(largestContour, new Gray(255), -1);
            mask.Draw(largestContour, new Gray(255), -1);

            //CvInvoke.cvShowImage("maska", mask2);
            //CvInvoke.cvShowImage("aplikovana maska", _temp1);

            byte white = 255;
            for (int y = 1; y < _temp1.Height - 1; y++)
            {
                for (int x = 15; x < _temp1.Width - 15; x++)
                {
                    if ((mask.Data[y, x - 3, 0] != white) &&
                        (mask.Data[y, x + 3, 0] != white) &&
                        (mask.Data[y, x, 0] != white))
                    {
                        if ((Math.Abs(_temp1.Data[y, x - 6, 0] - _temp1.Data[y, x, 0]) > 12) &&
                            (Math.Abs(_temp1.Data[y, x - 6, 0] - _temp1.Data[y, x, 0]) < 22))
                            fv.image.Data[y, x, 0] = white;
                    }
                }
            }
            fv.image = fv.image.SmoothMedian(3);
            //string f = "C:\\out2\\";
            //string [] part = input.FileName.Split('\\');
            //f += part[part.Length - 1];
            //fv.image.Save(f);

            //CvInvoke.cvShowImage("vysledek", mask);
            //CvInvoke.cvWaitKey(1000);

            return fv;
        }

        #endregion
    }
}
