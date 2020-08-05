using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupService.Models.Client
{
    public class Client
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        public Guid OrgID { get; set; }
        
        [ForeignKey("OrgID")]
        public Organization.Organization Organization { get; set; }

        public List<Project.Project> Projects { get; set; }
    }
}