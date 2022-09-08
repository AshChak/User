using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace User
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }

        public string Notes { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
