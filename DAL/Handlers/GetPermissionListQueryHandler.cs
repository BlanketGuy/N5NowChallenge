using DAL.Interfaces;
using DAL.Queries;
using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    public class GetPermissionListQueryHandler : IRequestHandler<GetPermissionListQuery, IEnumerable<Permission>>
    {
        private readonly IPermissionRepository _permissionRepository;
        public GetPermissionListQueryHandler(IPermissionRepository permissionRepository) 
        {
            _permissionRepository = permissionRepository;
        }
        public Task<IEnumerable<Permission>> Handle(GetPermissionListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_permissionRepository.Get());
        }
    }
}
