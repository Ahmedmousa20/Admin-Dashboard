using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Models
{
    public class DepartmentVM
    {

        public int Id { get; set; }

        [Required (ErrorMessage ="Name Required!")]
        [StringLength(50,ErrorMessage ="Max Lentgh is 50")]
        [MinLength(3,ErrorMessage ="Min Lentgh is 3")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Code Required!")]
        public String Code { get; set; }
    }
}
