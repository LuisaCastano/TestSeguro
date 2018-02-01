using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    public interface IClientPolicyRepository : IDisposable
    {
        List<ClientPolicy> GetClientPolicyByClient(int clientId);
        ClientPolicy GetClientPolicyById(int Id);
        void InsertClientPolicy(ClientPolicy clientPolicy);
        void DeleteClientPolicy(int Id);
        void UpdateClientPolicy(ClientPolicy clientPolicy);
        void Save();
    }
}
