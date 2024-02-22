using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class RoomUpdateDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Please Enter Room Number")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Room Image")]
        public string RoomCoverImage { get; set; }

        [Required(ErrorMessage = "Please Enter Price Information")]
        
        public int Price { get; set; }

        [Required(ErrorMessage = "Please Enter Room Title")]
        [StringLength(100,ErrorMessage ="A maximum of 100 characters is allowed")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Bed Count")]
        public string BedCount { get; set; }

        [Required(ErrorMessage = "Please Enter Bath Count")]
        public string BathCount { get; set; }
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Please Description")]
        public string Description { get; set; }
    }
}
