using System;

namespace SupService.Interfaces.Client
{
    public interface IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}