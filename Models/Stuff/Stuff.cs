using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SupService.Models.ProjectStaffMan;

namespace SupService.Models.Stuff
{
    public class Stuff
    {
        [Key] [Required] public Guid Id { get; set; }
        [Required] public string FName { get; set; }
        [Required] public string LName { get; set; }
        
        [Phone]  [DataType(DataType.PhoneNumber)]
        [Required]
        public string Phone { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [EmailAddress] [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)] 
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 4 and 255 characters", MinimumLength = 4)]
        public string Password { get; set; }

        public IEnumerable<ProjectStuffMan> Projects { get; set; }

        public IEnumerable<Message.Message> Messages { get; set; }
    }
}