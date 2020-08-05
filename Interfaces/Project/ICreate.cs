using System;

namespace SupService.Interfaces.Project
{
    public interface ICreate
    {
        public string Name { get; set; }
        public Guid ClientID { get; set; }
    }
}