using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Data;
using System.Data.Entity;

namespace Insurance.Core.CRUD
{
    public class ClientRepository : IClientRepository
    {
        private EnsurancePolicyEntities _context;

        public ClientRepository()
        {
            this._context = new EnsurancePolicyEntities();
        }

        public List<Client> GetClient()
        {
            var model = _context.Client.ToList();
            return model;
        }

        public Client GetClientById(int clientId)
        {
            var model = _context.Client.Find(clientId);
            return model;
        }

        public void InsertClient(Client client)
        {
            _context.Client.Add(client);
        }

        public void DeleteClient(int clientId)
        {
            var model = _context.Client.Find(clientId);
            _context.Client.Remove(model);
        }

        public void UpdateClient(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
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
