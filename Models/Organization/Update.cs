using System;
using SupService.Interfaces.Organization;

namespace SupService.Models.Organization
{
    public class Update: IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}