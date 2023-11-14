using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ChallengeDbContext _dbContext;

        public EmployeeRepository(ChallengeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPermission(int permissionId, int employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            var permission = _dbContext.Permissions.Find(permissionId);

            employee.Permissions.Add(permission);
        }
    }
}
