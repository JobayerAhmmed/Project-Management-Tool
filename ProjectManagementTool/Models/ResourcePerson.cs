using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementTool.Models
{
    public class ResourcePerson
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
    }
}