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
        private EnsurancePolicyEntities _context;

        public PolicyRepository()
        {
            this._context = new EnsurancePolicyEntities();
        }

        public List<Policy> GetPolicy()
        {
            var model = _context.Policy.Include(p => p.CoverageKind).ToList();
            return model;
        }

        public Policy GetPolicyById(int policyId)
        {
            var model = _context.Policy.Find(policyId);
            return model;
        }

        public List<CoverageKind> GetCoverageKind()
        {
            var model = _context.CoverageKind.ToList();
            return model;
        }

        //public List<RiskKind> GetRiskKind()
        //{
            
        //}

        public void InsertPolicy(Policy policy)
        {
            //Antes de crear una poliza validar que siga las reglas del negocio
            
            _context.Policy.Add(policy);
        }

        public void DeletePolicy(int policyId)
        {
            var model = _context.Policy.Find(policyId);
            _context.Policy.Remove(model);
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
