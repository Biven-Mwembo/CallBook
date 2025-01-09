using System.ComponentModel.DataAnnotations;

namespace CallBook.Models
{
    public class Contacts
    {
        public int Id { get; set; } // Primary Key

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(15, ErrorMessage = "Phone Number can't be longer than 15 characters")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string EmailAddress { get; set; }
    }
}
