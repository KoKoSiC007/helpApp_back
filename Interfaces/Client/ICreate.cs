using System;

namespace SupService.Interfaces.Client
{
    public interface ICreate
    {
        public string Name { get; set; }
        public Guid OrgID { get; set; }
    }
}