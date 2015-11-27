﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using BIO.Framework.Core.FeatureVector;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem
{

    public enum MinutiaeType { BIFURCATION, ENDING, NONE };
    //prevzato z http://www.stud.fit.vutbr.cz/~xvanaj00/bio/?page_id=175
    [Serializable]
    public class Minutiae
    {
        public int positionX;
        public int positionY;
        public MinutiaeType type;
    }
    
    public class VeinFeatureVector : IFeatureVector
    {
        public List<Minutiae> minutiae;

        public VeinFeatureVector()
        {
            this.minutiae = new List<Minutiae>();
        }

        public List<Minutiae> Minutiaes { get { return this.minutiae; } }
    }
}