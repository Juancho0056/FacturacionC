using Application.Application.Roles;
using Application.CommandQueries.Permisos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Roles.Query.GetUserRoles
{
    public class GetPermisosRolResponse
    {
        public ICollection<PermisoDto> Data { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
    }
}