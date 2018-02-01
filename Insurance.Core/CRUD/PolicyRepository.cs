using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Data;
using System.Data.Entity;

namespace Insurance.Core.CRUD
{
    public class PolicyRepository : IPolicyRepository
    {
        private InsuranceContext _context;

        public PolicyRepository(InsuranceContext insuarenceContext)
        {
            this._context = insuarenceContext;
        }

        public List<Policy> GetPolicy()
        {
            var model = _context.Policies.Include(p => p.CoverageKind).ToList();
            return model;
        }

        public Policy GetPolicyById(int policyId)
        {
            var model = _context.Policies.Find(policyId);
            return model;
        }

        public List<CoverageKind> GetCoverageKind()
        {
            var model = _context.CoverageKinds.ToList();
            return model;
        }

        //public List<RiskKind> GetRiskKind()
        //{
            
        //}

        public void InsertPolicy(Policy policy)
        {
            //Antes de crear una poliza validar que siga las reglas del negocio
            
            _context.Policies.Add(policy);
        }

        public void DeletePolicy(int policyId)
        {
            var model = _context.Policies.Find(policyId);
            _context.Policies.Remove(model);
        }

        public void UpdatePolicy(Policy policy)
        {
            _context.Entry(policy).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
