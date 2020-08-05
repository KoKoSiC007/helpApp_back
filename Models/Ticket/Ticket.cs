using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace SupService.Models.Ticket
{
    public class Ticket
    {
        [Key] [Required] public Guid Id { get; set; }

        [Required] public string Description { get; set; }

        [Required] [Timestamp] public byte[] CreatedAt { get; set; }

        [ForeignKey("ProjectId")]
        public Project.Project Project { get; set; }

        public Guid ProjectId { get; set; }
        
        [ForeignKey("ManagerId")]
        public Stuff.Stuff Manager { get; set; }

        public Guid ManagerId { get; set; }
        
        public List<Message.Message> Messages { get; set; }
    }
}