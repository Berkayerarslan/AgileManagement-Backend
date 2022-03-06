using Agile.Management.Domain.models;
using Agile.Management.Domain.repositories;
using AgileManagement.Core;
using AgileManagement.Persistence.EF.contexts;
using System.Linq;


namespace AgileManagement.Persistence.EF
{
    public class EFUserRepository : EFBaseRepository<ApplicationUser, AppDbContext>, IUserRepository
    {
        public EFUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override void Add(ApplicationUser entity)
        {
            base.Add(entity);

        }

        public ApplicationUser FindUserByEmail(string email)
        {
            return _dbSet.FirstOrDefault(x => x.Email == email);
        }
    }
}
