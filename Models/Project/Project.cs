using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SupService.Models.ProjectStaffMan;

namespace SupService.Models.Project
{
    public class Project
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        
        public Guid ClientID { get; set; }
        [ForeignKey("ClientID")]
        public Client.Client Client { get; set; }

        public IEnumerable<ProjectStuffMan> Managers { get; set; }
    }
}