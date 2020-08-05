using System;
using SupService.Interfaces.Project;

namespace SupService.Models.Project
{
    public class Create: ICreate
    {
        public string Name { get; set; }
        public Guid ClientID { get; set; }
    }
}