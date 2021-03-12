using System.ComponentModel.DataAnnotations.Schema;
using VentasApp.Domain.Common;

namespace VentasApp.Domain.Entities.Application
{
    [Table("permissions")]
    public class ApplicationPermission: AuditableEntity
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public string Slug { get; set; }
        public int MenuRoleId { get; set; }
        public ApplicationMenuRole MenuRole { get; set; }

    }
}
