using System.ComponentModel.DataAnnotations;

namespace User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        public string Notes { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
