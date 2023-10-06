using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacementProject.Models
{
    public class ProgramModel
    {
        public Guid Id { get; set; }
        public string ProgramTitle { get; set; }
        public string Summary { get; set; }
        public string ProgramDescription { get; set; }
        public string KeySkills { get; set; }
        public string ProgramBenefits { get; set; }
        public string ApplicationCriteria { get; set; }

        public string ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }
        public DateTime ApplicationOpen { get; set; }
        public DateTime ApplicationClose { get; set; }
        public string Duration { get; set; }
        public string ProgramLocation { get; set; }
        public bool FullyRemote { get; set; }
        public string MinQualifications { get; set; }
        public int MaxApplications { get; set; }
    }

}
