using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KaizenTest.Model
{
    public class Todo
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "My Todo")]
        public string todoDesc { get; set; }

        [Display(Name ="Status")]
        public bool isCompleted { get; set; }
    }
}
