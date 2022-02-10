using System.ComponentModel.DataAnnotations;

namespace CustomerAssignmentApplication.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
