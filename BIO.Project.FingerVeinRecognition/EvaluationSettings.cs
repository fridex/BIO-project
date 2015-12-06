using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Project.FingerVeinRecognition.VeinBiometricSystem;

namespace BIO.Project.FingerVeinRecognition
{
    class EvaluationSettings : 
        BIO.Framework.Extensions.Standard.Evaluation.Block.BlockEvaluationSettings<
        StandardRecord<StandardRecordData>, //standard database record
        EmguGrayImageInputData
    > {

        public EvaluationSettings() {
            this.addBlockToEvaluation(new VeinBiometricSystem.VeinProcessingBlockComponents1("Alg1").createBlock());
            //this.addBlockToEvaluation(new VeinBiometricSystem.VeinProcessingBlockComponents2("Alg2").createBlock());
            //this.addBlockToEvaluation(new VeinBiometricSystem.VeinProcessingBlockComponents3("Alg3").createBlock());
            //this.addBlockToEvaluation(new VeinBiometricSystem.VeinProcessingBlockComponents4("Alg4").createBlock());
            //this.addBlockToEvaluation(new VeinBiometricSystem.VeinProcessingBlockFused());
        }

        protected override Framework.Core.InputData.IInputDataCreator<StandardRecord<StandardRecordData>, EmguGrayImageInputData> createInputDataCreator() {
            return new InputDataCreator();
        }
    }
}
