using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementTool.ViewModels
{
    public class ProjectIndexViewModel
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Status { get; set; }
        public int NumberOfMembers { get; set; }
        public int NumberOfTasks { get; set; }
    }
}