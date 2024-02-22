using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage ="Service Icon is Required")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Please Enter Service Title")]
        [StringLength(100,ErrorMessage ="Maximum 100 characters is allowed")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
