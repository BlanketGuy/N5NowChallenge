using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ChallengeDbContext _dbContext;

        public PermissionRepository(ChallengeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Permission> Get()
        {
            return _dbContext.Permissions;
        }

        public void Modify(Permission permission)
        {
            _dbContext.Permissions.Update(permission);
        }
    }
}
