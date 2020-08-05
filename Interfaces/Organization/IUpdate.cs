using System;

namespace SupService.Interfaces.Organization
{
    public interface IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}