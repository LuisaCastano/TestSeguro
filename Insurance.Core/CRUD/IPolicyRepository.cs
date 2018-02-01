using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    interface IPolicyRepository : IDisposable
    {
        List<Policy> GetPolicy();
        Policy GetPolicyById(int PolicyId);
        void InsertPolicy(Policy Policy);
        void DeletePolicy(int PolicyId);
        void UpdatePolicy(Policy Policy);
        void Save();
    }
}
