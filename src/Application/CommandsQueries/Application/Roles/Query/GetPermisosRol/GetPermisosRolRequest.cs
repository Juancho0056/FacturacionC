using System.ComponentModel.DataAnnotations;
using VentasApp.Application.Common.Abstracts;

namespace Application.Application.Roles.Query.GetUserRoles
{
    
    public class GetPermisosRolRequest : QueryRequest<GetPermisosRolResponse>
    {
        [Required]
        public string Username { get; set; }
    }
}
