using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIO.Framework.Extensions.Standard.Database.InputDatabase;
using BIO.Framework.Extensions.Emgu.InputData;

namespace BIO.Project.FingerVeinRecognition
{
    class ProjectSettings :
        BIO.Project.ProjectSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData>,
        IStandardProjectSettings<StandardRecord<StandardRecordData>> {

        #region IStandardProjectSettings<StandardRecord<StandardRecordData>> Members

        /// <summary>
        /// Počet vstupních vzorků na osobu pro tvorbu šablony
        /// </summary>
        public int TemplateSamples {
            get {
                return 1;
            }
        }

        #endregion

        /// <summary>
        /// Vytvoření databáze
        /// </summary>
        public override Framework.Core.Database.IDatabaseCreator<StandardRecord<StandardRecordData>> getDatabaseCreator() {
            return new DatabaseCreator(@"../../../../vein");
        }

        /// <summary>
        /// Registrace bloku
        /// </summary>
        protected override Framework.Core.Evaluation.Block.IBlockEvaluatorSettings<StandardRecord<StandardRecordData>, EmguGrayImageInputData> getEvaluatorSettings() {
            return new EvaluationSettings();
        }
    }
}
