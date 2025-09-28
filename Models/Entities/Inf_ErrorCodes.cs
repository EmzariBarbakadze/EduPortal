using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_ErrorCodes : BaseClass3
    {
        [Key]
        public int Code { get; set; }

        // ---------------------------------

        public List<ExceptionLogs> ExceptionLogs { get; set; }
    }
}
