using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppExam.Models
{
    public class StudentsMarks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string ExamName { get; set; }
        public int TotalNumber { get; set; }

        public int ObtainedNumber { get; set; }




        //[Required]
        //[DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }



        //[Required]
        //[DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }


        [ForeignKey(nameof(Students.StudentId))]
        public int StudentId { get; set; }


        public Students? Students { get; set; }

    }
}