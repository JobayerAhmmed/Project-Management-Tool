using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementTool.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Code Name")]
        public string CodeName { get; set; }
        
        public string Description { get; set; }

        [Display(Name = "Possible Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Possible End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Duration (in days)")]
        public string Duration { get; set; }

        [Display(Name = "Upload File")]
        public string FilePath { get; set; }

        public string Status { get; set; }
    }
}