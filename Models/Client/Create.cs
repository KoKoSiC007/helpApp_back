using System;
using SupService.Interfaces.Client;

namespace SupService.Models.Client
{
    public class Create: ICreate
    {
        public string Name { get; set; }
        public Guid OrgID { get; set; }
    }
}