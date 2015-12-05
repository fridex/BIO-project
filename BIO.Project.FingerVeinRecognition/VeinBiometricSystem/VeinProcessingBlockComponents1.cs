using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Emgu.InputData;
using BIO.Framework.Extensions.Emgu.FeatureVector;
using BIO.Framework.Extensions.Standard.Template;
using BIO.Framework.Core.Comparator;
using BIO.Framework.Core.FeatureVector;
using BIO.Project.FingerVeinRecognition.VeinBiometricSystem;

namespace BIO.Project.FingerVeinRecognition.VeinBiometricSystem {
    public class VeinProcessingBlockComponents1 : BIO.Framework.Extensions.Standard.Block.InputDataProcessingBlockSettings<
          EmguGrayImageInputData,
          VeinFeatureVector1,
          Template<VeinFeatureVector1>,
          VeinFeatureVector1
    > {

        public VeinProcessingBlockComponents1(string name) : base(name){
        }

        /// <summary>
        /// Extraktor vektoru rysů, který bude použit jako šablona ze vstupních dat.
        /// </summary>
        protected override IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector1> createTemplatedFeatureVectorExtractor() {
            return new VeinFeatureVectorExtractor1();
        }

        /// <summary>
        /// Extraktor vektoru rysů ze vstupních dat.
        /// </summary>
        protected override IFeatureVectorExtractor<EmguGrayImageInputData, VeinFeatureVector1> createEvaluationFeatureVectorExtractor() {
            return new VeinFeatureVectorExtractor1();
        }

        /// <summary>
        /// Registrace porovnávacího algoritmu. Porovnává se šablona v databázi s aktuálním vektorem rysů.
        /// </summary>
        protected override Framework.Core.Comparator.IComparator<VeinFeatureVector1, Template<VeinFeatureVector1>, VeinFeatureVector1> createComparator() {
            return new BIO.Framework.Extensions.Standard.Comparator.Comparator<VeinFeatureVector1, Template<VeinFeatureVector1>, VeinFeatureVector1>(
                this.createFeatureVectorComparator(),
                this.createScoreSelector()
            );
        }

        /// <summary>
        /// Registrace porovnávacího algoritmu. Porovnává se šablona v databázi s aktuálním vektorem rysů.
        /// </summary>
        private IFeatureVectorComparator<VeinFeatureVector1, VeinFeatureVector1> createFeatureVectorComparator() {
            return new VeinFeatureVectorComparator1();
        }

        /// <summary>
        /// Jako výsledné skóre porovnání je vybrána nejmenší hodnota
        /// </summary>
        /// <returns></returns>
        private Framework.Extensions.Standard.Comparator.IScoreSelector createScoreSelector() {
            return new BIO.Framework.Extensions.Standard.Comparator.MinScoreSelector();
        }
    }
}
