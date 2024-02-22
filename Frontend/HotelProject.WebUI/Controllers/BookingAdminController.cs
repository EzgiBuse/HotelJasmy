using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    //Admin Panel Controller for Bookings
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("http://localhost:5191/api/Booking");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsondata = await responsemessage.Content.ReadAsStringAsync();
                var val = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsondata);
                return View(val);
            }
            return View();
        }
        public async Task<IActionResult> ApproveReservation(int id, string status)
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5191/api/Booking/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var reservation = JsonConvert.DeserializeObject<Booking>(content);

                // Modify the reservation object for status
                reservation.Status = status;

                // Serialize the modified reservation object back to JSON
                var jsonData = JsonConvert.SerializeObject(reservation);
                var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                // Send the updated reservation back to the server
                var putResponse = await client.PutAsync("http://localhost:5191/api/Booking/", stringContent);

                if (putResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }
    }
}
