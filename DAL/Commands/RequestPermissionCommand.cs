using MediatR;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Commands
{
    public record RequestPermissionCommand(PermissionType PermissionType) : IRequest;
}
