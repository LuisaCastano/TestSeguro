using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Data;
using System.Data.Entity;

namespace Insurance.Core.CRUD
{
    class PolicyRepository : IPolicyRepository
    {
        private InsuranceContext _context;

        public PolicyRepository(InsuranceContext insuarenceContext)
        {
            this._context = insuarenceContext;
        }

        public List<Policy> GetPolicy()
        {
            var model = _context.Policies.ToList();
            return model;
        }

        public Policy GetPolicyById(int policyId)
        {
            var model = _context.Policies.Find(policyId);
            return model;
        }

        public void InsertPolicy(Policy policy)
        {
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
