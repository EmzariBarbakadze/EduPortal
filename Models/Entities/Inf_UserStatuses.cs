using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_UserStatuses : BaseClass3
    {
        [Key]
        public int StatusId { get; set; }

        // ---------------------------------------

        public List<Users> Users { get; set; }
    }
}
