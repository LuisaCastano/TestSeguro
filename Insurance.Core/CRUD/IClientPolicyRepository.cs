using System;
using System.Collections.Generic;
using Insurance.Data;

namespace Insurance.Core.CRUD
{
    interface IClientPolicyRepository : IDisposable
    {
        List<ClientPolicy> GetClientPolicyByClient(int clientId);
        ClientPolicy GetClientPolicyById(int clientId, int policyId);
        void InsertClientPolicy(ClientPolicy clientPolicy);
        void DeleteClientPolicy(int clientId, int policyId);
        void UpdateClientPolicy(ClientPolicy clientPolicy);
        void Save();
    }
}
