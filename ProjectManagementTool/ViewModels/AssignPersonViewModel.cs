using ProjectManagementTool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementTool.ViewModels
{
    public class AssignPersonViewModel
    {
        public string ProjectId { get; set; }

        public string UserId { get; set; }

        public IEnumerable<SelectListItem> Projects { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<ResourcePersonViewModel> ResourcePersons { get; set; }
    }
}