using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IConfiguration _configuration;

        public EstudianteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: Estudiante
        public async Task<IActionResult> Index()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/estudiantes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(apiResponse);
                }
            }
            return View(estudiantes);
        }

        // GET: Estudiante/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Estudiante estudiante = new Estudiante();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/estudiantes/{id}"))
                {

                    try
                    {
                        if (!response.IsSuccessStatusCode)
                            throw new Exception("No se encuentra registro");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        estudiante = JsonConvert.DeserializeObject<Estudiante>(apiResponse);

                    }
                    catch
                    {
                        Response.StatusCode = 404;
                        return View("_Error");
                    }

                }
            }
            return View(estudiante);
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string stringData = JsonConvert.SerializeObject(estudiante);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {

                        using (var response = await httpClient.PostAsync($"{_configuration["API:Url"]}/api/estudiantes", contentData))
                        {

                            try
                            {
                                if (!response.IsSuccessStatusCode)
                                    throw new Exception("No se encuentra registro");
                                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                                return RedirectToAction("Index");

                            }
                            catch
                            {
                                Response.StatusCode = 404;
                                return View("_Error");
                            }

                        }
                    }
                }
                else
                {
                    Response.StatusCode = 404;
                    return View("_Error");
                }
            }
            catch
            {
                Response.StatusCode = 404;
                return View("_Error");
            }
        }

        // GET: Estudiante/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Estudiante estudiante = new Estudiante();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/estudiantes/{id}"))
                {

                    try
                    {
                        if (!response.IsSuccessStatusCode)
                            throw new Exception("No se encuentra registro");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        estudiante = JsonConvert.DeserializeObject<Estudiante>(apiResponse);

                    }
                    catch
                    {
                        Response.StatusCode = 404;
                        return View("_Error");
                    }

                }
            }
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Estudiante estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                 
                    string stringData = JsonConvert.SerializeObject(estudiante);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {

                        using (var response = await httpClient.PutAsync($"{_configuration["API:Url"]}/api/estudiantes/{id}", contentData))
                        {

                            try
                            {
                                if (!response.IsSuccessStatusCode)
                                    throw new Exception("No se encuentra registro");
                                ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                                return RedirectToAction("Index");

                            }
                            catch
                            {
                                Response.StatusCode = 404;
                                return View("_Error");
                            }

                        }
                    }
                }
                else
                {
                    Response.StatusCode = 404;
                    return View("_Error");
                }
            }
            catch
            {
                Response.StatusCode = 404;
                return View("_Error");
            }
        }

        // GET: Estudiante/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Estudiante estudiante = new Estudiante();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/estudiantes/{id}"))
                {

                    try
                    {
                        if (!response.IsSuccessStatusCode)
                            throw new Exception("No se encuentra registro");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        estudiante = JsonConvert.DeserializeObject<Estudiante>(apiResponse);

                    }
                    catch
                    {
                        Response.StatusCode = 404;
                        return View("_Error");
                    }

                }
            }
            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Estudiante estudiante)
        {
            try
            {
                string stringData = JsonConvert.SerializeObject(estudiante);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.DeleteAsync($"{_configuration["API:Url"]}/api/estudiantes/{id}"))
                    {

                        try
                        {
                            if (!response.IsSuccessStatusCode)
                                throw new Exception("No se encuentra registro");
                            ViewBag.Message = response.Content.ReadAsStringAsync().Result;
                            return RedirectToAction("Index");

                        }
                        catch
                        {
                            Response.StatusCode = 404;
                            return View("_Error");
                        }

                    }
                }

            }
            catch
            {
                Response.StatusCode = 404;
                return View("_Error");
            }
        }
    }
}