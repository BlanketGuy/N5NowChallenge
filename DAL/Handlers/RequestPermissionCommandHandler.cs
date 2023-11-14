using DAL.Commands;
using DAL.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Handlers
{
    internal class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestPermissionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.Employees.AddPermission(request.PermissionType.PermissionId, request.PermissionType.EmployeeId);
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
