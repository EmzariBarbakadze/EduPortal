using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_RestrictionLevels : BaseClass3
    {
        [Key]
        public int RestrictionLevelId { get; set; }

        // ---------------------------------------------------

        public List<UsersSessions> UsersSessions { get; set; }
    }
}
