using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem
{
    class VeinProcessingBlockFused : 
        BIO.Framework.Extensions.Standard.Block.MultipleInputDataProcessingBlock<EmguGrayImageInputData>        
    {

        public VeinProcessingBlockFused() : base("fusion") {
        {
            VeinProcessingBlockComponents1 fbc = new VeinProcessingBlockComponents1("1");
            this.addInternalBlock(fbc.createBlock());
        }
        {
            VeinProcessingBlockComponents2 fbc = new VeinProcessingBlockComponents2("2");
            this.addInternalBlock(fbc.createBlock());
        }
        {
            VeinProcessingBlockComponents3 fbc = new VeinProcessingBlockComponents3("3");
            this.addInternalBlock(fbc.createBlock());
        }
        {
            VeinProcessingBlockComponents4 fbc = new VeinProcessingBlockComponents4("4");
            this.addInternalBlock(fbc.createBlock());
        }
    }

    class ScoreResolver : BIO.Framework.Core.Block.IScoreFusionBlock
    {

        public Framework.Core.Comparator.MatchingScore resolve(Framework.Core.Comparator.MatchingScore matchingSubscores)
        {
            double val = 0.0;
            foreach (string subscoreName in matchingSubscores.getSubscoreNames())
            {
                val += matchingSubscores.getSubscore(subscoreName).Score;
            }
            return matchingSubscores.cloneWithDifferentScore(val);
        }

    }

    protected override BIO.Framework.Core.Block.IScoreFusionBlock createMatchingScoreFusionBlock()
    {
        return new ScoreResolver();
    }
}
}
