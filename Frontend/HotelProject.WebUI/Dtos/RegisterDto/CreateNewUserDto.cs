using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage="Name Field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname Field is Required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Username Field is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail Field is Required")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Password Field is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Field is Required")]
        [Compare("Password",ErrorMessage="Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
