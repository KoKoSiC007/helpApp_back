using SupService.Interfaces.Stuff;

namespace SupService.Models.Stuff
{
    public class Create: ICreate
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}