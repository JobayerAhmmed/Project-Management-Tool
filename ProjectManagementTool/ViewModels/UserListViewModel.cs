using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementTool.ViewModels
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Designation { get; set; }
    }
}