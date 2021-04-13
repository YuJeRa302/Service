using IngredientServer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IngredientServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        // GET: api/payment
        [HttpGet]
        public IEnumerable<string> GetPayment()
        {
            return new string[] { "payment", "payment2" };
        }


        // GET  api/payment/5
        [HttpGet("{id}")]
        public string GetPayment(int id)
        {
            return "valuebyNumber";
        }


        [HttpPut("{number}")]
        public IActionResult payPurchase([FromRoute] string accountNumber, [FromBody] AccountDTO accountDTO)
        {

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:9074/api/accounts/bynumber/" + accountNumber);

            string jsonRequest = JsonSerializer.Serialize(accountDTO);

            request.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            client.SendAsync(request).ContinueWith(responseTask => { });

            return Ok();
        }
    }
}
