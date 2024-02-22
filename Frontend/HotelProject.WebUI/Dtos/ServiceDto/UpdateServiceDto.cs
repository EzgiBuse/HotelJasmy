using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
       
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Service Icon is Required")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Please Enter Service Title")]
        [StringLength(100, ErrorMessage = "Maximum 100 characters is allowed")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Service Description")]
        [StringLength(500, ErrorMessage = "Maximum 500 characters is allowed")]
        public string Description { get; set; }
    }
}
