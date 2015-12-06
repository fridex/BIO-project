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
using System.Drawing;

namespace BIO.Project.FingerVeinRecognition
{
    class VeinFeatureVectorExtractor1 : IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector1>
    {
        public VeinFeatureVector1 extractFeatureVector(EmguGrayImageInputData input)
        {
            const int bound = 5;
            VeinFeatureVector1 fv = new VeinFeatureVector1();
            int x_start = 0;
            int y_start = 0;
            int x_end = input.Image.Width;

            byte last_val;

            // nepekne vysledky :(
            //input.Image._EqualizeHist();

            // x_start
            last_val = input.Image.Data[input.Image.Height / 2, 0, 0];
            for (int i = 1; i < input.Image.Width / 2; i++) {
                if (input.Image.Data[input.Image.Height / 2, i, 0] - last_val > bound) {
                    x_start = i;
                    break;
                }
                last_val = input.Image.Data[input.Image.Height / 2, i, 0];
            }

            // x_end
            // v obrazkoch je na pravej strane casto cierny okraj, ten treba preskocit => -10px
            last_val = input.Image.Data[input.Image.Height / 2, input.Image.Width - 10, 0];
            for (int i = input.Image.Width - 11; i > input.Image.Width / 2; i--)
            {
                if (input.Image.Data[input.Image.Height / 2, i, 0] - last_val > bound)
                {
                    x_end = i;
                    break;
                }
                last_val = input.Image.Data[input.Image.Height / 2, i, 0];
            }

            
            // y_start
            last_val = input.Image.Data[0, input.Image.Width / 2, 0];
            for (int i = 1; i < input.Image.Height / 4; i++)
            {
                if (input.Image.Data[i, input.Image.Width / 2, 0] - last_val < -bound)
                {
                    y_start = i;
                    break;
                }
                last_val = input.Image.Data[i, input.Image.Width / 2, 0];
            }
            

            input.Image.ROI = new Rectangle(x_start, y_start, x_end, input.Image.Height);
        
            // print
            //string f = "C:\\Users\\user\\Desktop\\out\\";
            //string [] part = input.FileName.Split('\\');
            //f += part[part.Length - 1];
            //input.Image.Save(f);
        
            fv.img = input.Image.Clone();
            
            return fv;
        }
    }
}
