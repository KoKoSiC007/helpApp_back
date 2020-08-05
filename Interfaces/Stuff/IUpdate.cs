using System;

namespace SupService.Interfaces.Stuff
{
    public interface IUpdate
    {
        public Guid Id { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}