using System;
using SupService.Interfaces.Project;

namespace SupService.Models.Project
{
    public class Update: IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}