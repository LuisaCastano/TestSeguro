using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    public interface IPolicyRepository : IDisposable
    {
        List<Policy> GetPolicy();
        Policy GetPolicyById(int PolicyId);
        List<CoverageKind> GetCoverageKind();
        List<RiskKind> GetRiskKind();
        void InsertPolicy(Policy Policy);
        void DeletePolicy(int PolicyId);
        void UpdatePolicy(Policy Policy);
        void Save();
    }
}
