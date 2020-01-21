using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRoleManagement.Models
{
    public class RoleTransition
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 RoleTransitionId { get; set; }


        [Required]
        public String Discription { get; set; }

        public virtual TeacherRole From { get; set; }

        public virtual TeacherRole To { get; set; }
    }
}
