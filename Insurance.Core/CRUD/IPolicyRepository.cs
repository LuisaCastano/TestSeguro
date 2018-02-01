using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    interface IPolicyRepository : IDisposable
    {
        List<Policy> GetPolicy(int policyId);
        Policy GetPolicyById(int PolicyId);
        void InsertPolicy(Policy Policy);
        void DeleteClientPolicy(int PolicyId);
        void UpdatePolicy(Policy Policy);
        void Save();
    }
}
