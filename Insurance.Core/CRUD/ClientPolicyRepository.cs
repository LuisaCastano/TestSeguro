﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Data;
using System.Data.Entity;

namespace Insurance.Core.CRUD
{
    public class ClientPolicyRepository : IClientPolicyRepository
    {
        private EnsurancePolicyEntities _context;

        public ClientPolicyRepository()
        {
            this._context = new EnsurancePolicyEntities();
        }

        public List<ClientPolicy> GetClientPolicy()
        {
            var model = _context.ClientPolicy.ToList();
            return model;
        }

        public List<ClientPolicy> GetClientPolicyByClient(int clientId)
        {
            var model = _context.ClientPolicy.Where(x => x.ClientId == clientId).ToList();
            return model;
        }

        public ClientPolicy GetClientPolicyById(int Id)
        {
            var model = _context.ClientPolicy.Find(Id);
            return model;
        }

        public void InsertClientPolicy(ClientPolicy clientPolicy)
        {
            _context.ClientPolicy.Add(clientPolicy);
        }

        public void DeleteClientPolicy(int Id)
        {
            var model = _context.ClientPolicy.Find(Id);
            _context.ClientPolicy.Remove(model);
        }

        public void UpdateClientPolicy(ClientPolicy clientPolicy)
        {
            _context.Entry(clientPolicy).State = EntityState.Modified;
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
