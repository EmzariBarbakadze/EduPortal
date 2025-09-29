using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Roles : BaseClass3
    {
        [Key]
        public int RoleId { get; set; }

        // -------------------------------------

        public List<UsersRoles> UsersRoles { get; set; }
    }
}
