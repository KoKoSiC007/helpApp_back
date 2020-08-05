using System;
using SupService.Interfaces.Client;

namespace SupService.Models.Client
{
    public class Update: IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}