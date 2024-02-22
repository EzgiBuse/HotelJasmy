using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{  
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        { //Booking reservation by guests
            createBookingDto.Status = "Waiting for Approval";
            createBookingDto.Description = "no description";
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
           await client.PostAsync("http://localhost:5191/api/Booking", stringContent);
          
                return RedirectToAction("Index","Booking");
            
        }
    }
}
