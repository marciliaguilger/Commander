using System.ComponentModel.DataAnnotations;

namespace commander.Models
{
    public class Command
    {
        [Key] //por convenção o Id é entendido como PK mas esta informação diz que é uma PK
        public int Id { get; set; }       
        [Required] //os campos não podem ser nulos
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}