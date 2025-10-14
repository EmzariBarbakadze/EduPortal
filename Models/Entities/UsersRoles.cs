using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class UsersRoles : BaseClass2
    {
        [Key]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }

        // -----------------------------------------------

        [ForeignKey("UserId")]
        public Users User { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
    }
}
