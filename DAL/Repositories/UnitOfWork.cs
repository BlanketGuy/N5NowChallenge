using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallengeDbContext _dbContext;
        public IPermissionRepository Permissions { get; }
        public IEmployeeRepository Employees { get; }

        public UnitOfWork(ChallengeDbContext dbContext, IPermissionRepository permissionRepository, IEmployeeRepository employeeRepository)
        {
            _dbContext = dbContext;
            Permissions = permissionRepository;
            Employees = employeeRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
