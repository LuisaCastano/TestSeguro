using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    interface IClientRepository : IDisposable
    {
        List<Client> GetClient();
        Client GetClientById(int clientId);
        void InsertClient(Client client);
        void DeleteClient(int clientId);
        void UpdateClient(Client client);
        void Save();
    }
}
