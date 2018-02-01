using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    interface IClientPolicyRepository : IDisposable
    {
        List<ClientPolicy> GetClientPolicyByClient(int clientId);
        ClientPolicy GetClientPolicyById(int clientPolicyId);
        void InsertClientPolicy(ClientPolicy clientPolicy);
        void DeleteClientPolicy(int clientPolicyId);
        void UpdateClientPolicy(ClientPolicy clientPolicy);
        void Save();
    }
}
