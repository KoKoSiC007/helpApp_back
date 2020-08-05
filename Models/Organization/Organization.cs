using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupService.Models.Organization
{
    public class Organization
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        public List<Client.Client> Clients { get; set; }
        
        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}