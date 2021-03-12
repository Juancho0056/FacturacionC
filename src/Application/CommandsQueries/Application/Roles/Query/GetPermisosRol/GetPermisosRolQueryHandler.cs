using Application.CommandQueries.Permisos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Application;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentasApp.Application.Common.Abstracts;
using VentasApp.Application.Common.Interfaces;
using VentasApp.Application.Common.Models;
using VentasApp.Domain.Entities.Application;

namespace Application.Application.Roles.Query.GetUserRoles
{
    public class GetPermisosRolHandler : QueryRequestHandler<GetPermisosRolRequest, GetPermisosRolResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public GetPermisosRolHandler(IApplicationDbContext context, IMapper mapper,
             UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public override async Task<GetPermisosRolResponse> HandleQuery(GetPermisosRolRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ApplicationPermission> query = (from roles in _context.applicationroles
                                                 join userrole in _context.applicationuserroles on roles.Id equals userrole.RoleId
                                                 join users in _context.applicationusers on userrole.UserId equals users.Id
                                                 join menurole in _context.menusroles on userrole.RoleId equals menurole.RoleId
                                                 join permission in _context.permissions on menurole.Id equals permission.MenuRoleId
                                                       where users.UserName == request.Username
                                                 select permission
                                        );
            
            if (request.sort != null)
                query = request.sort.Length > 0 ? query = query.ApplySorting(request.sort) : query = query.OrderBy(c => c.Id);

            int count = query.Count();

            var pages = ((int)Math.Ceiling((double)count / request.Limit));
            var data = await query.AsNoTracking()
                            .Skip((request.Page - 1) * request.Limit)
                            .Take(request.Limit).ProjectTo<PermisoDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

            var vm = new GetPermisosRolResponse
            {
                Data = data,
                Count = count,
                Pages = pages
            };

            return vm;

        }
    }
}
