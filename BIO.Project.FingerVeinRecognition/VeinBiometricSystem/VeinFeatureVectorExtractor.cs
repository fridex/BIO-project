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

        int[] neighbours = new int[18] { -1,-1,-1,0,-1,1,0,1,1,1,1,0,1,-1,0,-1,-1,-1 };

        public VeinFeatureVector extractFeatureVector(EmguGrayImageInputData input) {
            //pokud je obrazek sirsi nez 300px, zmensi se na sirku 300. Viz pdf
            Image<Gray, byte> smaller;
            if (input.Image.Width > 300)
            {
                smaller = input.Image.Resize(300.0 / input.Image.Width, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }
            else
            {
                smaller = input.Image.Resize(1.0, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            }
            
            EmguGrayImageFeatureVector fv = new EmguGrayImageFeatureVector(new System.Drawing.Size(smaller.Width, smaller.Height));
            fv.FeatureVector = smaller.Copy();

            //TODO upravit obrazek aby se jednalo pouze o samotne papilarni linie
            //mozna pujde pouzit jiz implementovane funkce jako SmoothGaussian, HoughLines, SmoothMedian, SmoothBlur, ThresholdAdaptive
            //nejlepsi by bylo ale pouzit adaptive histogram equalization (CLAHE), dle pdf http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.476.8969&rep=rep1&type=pdf

            //funkce CLAHE() je dostupna az v EMGU 3, takze bych to asi stahl a zkusil nahradit


            //extrakce rysu. Funkce potrebuje papilarni linie o sirce jednoho pixelu
            //neni vubec otestovane, jen nabusene :)
            VeinFeatureVector featureVector = extractFeature(fv);

            return featureVector;
        }

        VeinFeatureVector extractFeature(EmguGrayImageFeatureVector fv)
        {
            VeinFeatureVector featureVector = new VeinFeatureVector();
            MinutiaeType minutiaeType;
            for (int y = 1; y < fv.FeatureVector.Height; y++)
            {
                for (int x = 1; x < fv.FeatureVector.Width; x++)
                {
                    minutiaeType = minutiaeAtPos(x, y, fv);
                    if (minutiaeType != MinutiaeType.NONE)
                    {
                        Minutiae minutiae = new Minutiae();
                        minutiae.positionX = x;
                        minutiae.positionY = y;
                        minutiae.type = minutiaeType;

                        featureVector.Minutiaes.Add(minutiae);
                    }
                }
            }
            return featureVector;
        }

        MinutiaeType minutiaeAtPos(int  x, int y, EmguGrayImageFeatureVector fv)
        {
            int neighPix = 0;
            for (int i = 0; i < 16; i += 2)
            {
                if (fv.FeatureVector.Data[y + neighbours[i], x + neighbours[i+1], 0] !=
                    fv.FeatureVector.Data[y + neighbours[i+2], x + neighbours[i + 3], 0])
                        neighPix += Math.Abs(fv.FeatureVector.Data[y + neighbours[i], x + neighbours[i + 1], 0]
                                    - fv.FeatureVector.Data[y + neighbours[i + 2], x + neighbours[i + 3], 0]);
            }
            if (neighPix == 2)
                return MinutiaeType.ENDING;
            else if (neighPix == 6)
                return MinutiaeType.BIFURCATION;
            else
                return MinutiaeType.NONE;
        }

        #endregion
    }
}
