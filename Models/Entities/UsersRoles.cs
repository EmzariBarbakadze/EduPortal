using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class UsersRoles : BaseClass2
    {
        [Key]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        // -----------------------------------------------

        public Users Users { get; set; }

        public Roles Roles { get; set; }
    }
}
