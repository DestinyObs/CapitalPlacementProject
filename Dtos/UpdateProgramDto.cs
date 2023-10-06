using CapitalPlacementProject.ENUMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapitalPlacementProject.Dtos
{
    public class UpdateProgramDto
    {
        public string ProgramTitle { get; set; }

        public string Summary { get; set; }

        public string ProgramDescription { get; set; }

        public List<Skills> ApplicantSkills { get; set; } = new List<Skills>();

        public List<string> Benefits { get; set; } = new List<string>();

        public List<string> ApplicationCriteria { get; set; } = new List<string>();

        public ProgramType ProgramType { get; set; }

        public DateTime ProgramStart { get; set; }

        public DateTime ApplicationOpen { get; set; }

        public DateTime ApplicationClose { get; set; }

        public string Duration { get; set; }

        public List<ProgramLocationDto> ProgramLocations { get; set; } = new List<ProgramLocationDto>();

        public bool FullyRemote { get; set; }

        public MinQualification MinQualifications { get; set; }

        public int MaxApplications { get; set; }
    }
}
