using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppExam.Models
{
    [Table(nameof(Students))]
    public class Students
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }


        [Required]
        //[StringLength(50)]
        public string Name { get; set; }

        public int Class { get; set; }


        //public bool? Regular { get; set; }

        public ICollection<StudentsMarks> studentsMarks { get; set; } = [];
    }
}
