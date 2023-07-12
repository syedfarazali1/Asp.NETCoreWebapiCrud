using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practicemvc.Models;
using PracticeProject.Models;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;

namespace Practicemvc.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client = new HttpClient();
        private readonly ILogger<HomeController> _logger;
     
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           List<StudentDetail> sd = new List<StudentDetail>();
            client.BaseAddress = new Uri("https://localhost:7198/");
            var response = await client.GetAsync("api/StudentDt");
            if (response.IsSuccessStatusCode)
            {
                sd = await response.Content.ReadFromJsonAsync<List<StudentDetail>>();
            }
            return View(sd);

        }
        public async Task<IActionResult> Create()
        {
         
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDetail student)
        {
            client.BaseAddress = new Uri("https://localhost:7198/api/StudentDt");
            var response = await client.PostAsJsonAsync("StudentDt", student);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");

        }
        public async Task<IActionResult> Details(int id)
        {
           StudentDetail sd = new StudentDetail();
            client.BaseAddress = new Uri("https://localhost:7198/");
            var response = await client.GetAsync("api/StudentDt/"+id);
            if (response.IsSuccessStatusCode)
            {
                sd = await response.Content.ReadFromJsonAsync<StudentDetail>();
            }
            return View(sd);

        }
        public async Task<IActionResult> Delete(int id)
        {
            client.BaseAddress = new Uri("https://localhost:7198/");
            var response = await client.DeleteAsync("api/StudentDt/"+id);
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            StudentDetail sd = new StudentDetail();
            client.BaseAddress = new Uri("https://localhost:7198/");
            var response = await client.GetAsync("api/StudentDt/" + id);
            if (response.IsSuccessStatusCode)
            {
                sd = await response.Content.ReadFromJsonAsync<StudentDetail>();
            }
            return View(sd);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(StudentDetail student)
        {
            client.BaseAddress = new Uri("https://localhost:7198/api/StudentDt");
            var response = await client.PutAsJsonAsync("StudentDt", student);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(student);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}