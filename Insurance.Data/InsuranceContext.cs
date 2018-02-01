using System.Data.Entity;

namespace Insurance.Data
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext()
            :base("name:EnsurancePolicyEntities")
        {
        }

        public DbSet<Policy> Policies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientPolicy> ClientPolicies { get; set; }
    }
}
