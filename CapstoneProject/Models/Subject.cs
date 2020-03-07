using Newtonsoft.Json;

namespace CapstoneProject.DataAccess.Subject
{
    public class Subject
    {
        [JsonProperty("Qualification Code")]
        public string QualificationCode { get; set; }

        [JsonProperty("Module Code")]
        public string ModuleCode { get; set; }

        public string Title { get; set; }

        [JsonProperty("C/E")]
        public string CE { get; set; }

        [JsonProperty("Pre/Co Requisites")]
        public string PreCoRequisites { get; set; }

        public string DeliveryMode { get; set; }

        [JsonProperty("Nominal Hours")]
        public string NominalHours { get; set; }

        [JsonProperty("Estimated Supervised/Face-To-Face Training Hours")]
        public int EstimatedSupervisedHours { get; set; }

        [JsonProperty("Estimated Individual  Study/Research Time")]
        public int EstimatedIndividualStudyResearchTime { get; set; }

        public string PeriodType { get; set; }

        [JsonProperty("Period Value")]
        public int PeriodValue { get; set; }

        [JsonProperty("Delivery Sequence")]
        public int DeliverySequence { get; set; }

        public string OffsetCommencement { get; set; }

        public string Duration { get; set; }

        public string ClusterCode { get; set; }

        public string AssessmentStrategy { get; set; }

        [JsonProperty("Trainer/Assessor")]
        public string Trainer { get; set; }
    }
}
