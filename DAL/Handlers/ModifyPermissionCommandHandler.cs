using DAL.Commands;
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
    internal class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionCommand>
    {
		private readonly IUnitOfWork _unitOfWork;
		public ModifyPermissionCommandHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
        public Task Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
			try
			{
                _unitOfWork.Permissions.Modify(request.Permission);
				_unitOfWork.Commit();
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
