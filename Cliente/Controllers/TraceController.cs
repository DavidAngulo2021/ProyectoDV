using Cliente.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace Cliente.Controllers
{
    public class TraceController : Controller
    {
        private readonly HttpClient _httpClient;
        
        public TraceController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5072/api");
        }


        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/api/Lista");
            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();
                //var traces = JsonConvert.DeserializeObject<List<TraceViewModel>>(content);
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                var traces = JsonConvert.DeserializeObject<List<TraceViewModel>>(responseObject.response.ToString());



                return View("Index", traces);
            }
            else
            {
                // Manejar el caso donde la solicitud no fue exitosa
                // Por ejemplo, mostrar un mensaje de error o redirigir a una página de error
                // En este caso, simplemente devolvemos una vista vacía
                return View(new List<TraceViewModel>());
            }





        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TraceViewModel trace)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(trace);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/api/Guardar", content);

                if (response.IsSuccessStatusCode)
                {
                    // Manejar el caso de creación exitosa.
                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejar el caso de error en la solicitud POST, por ejemplo, mostrando un mensaje de error.
                    ModelState.AddModelError(string.Empty, "Error al crear");
                }
            }
            return View(trace);
        }



    }
}
