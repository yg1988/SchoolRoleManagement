using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRoleManagement.Models
{
    public class TeacherRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 TeacherRoleId { get; set; }

        [Required]
        public String RoleName { get; set; }

        public bool RequireTenure { get; set; }
    }
}
