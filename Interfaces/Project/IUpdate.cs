using System;

namespace SupService.Interfaces.Project
{
    public interface IUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}