using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PrestamoLibrosWebApp.Models.Helper;
using WebApp.ViewModels;

namespace PrestamoLibrosWebApp.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IConfiguration _configuration;

        public PrestamoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: Prestamo
        public async Task<ActionResult> Index()
        {
            List<Prestamo> prestamos = new List<Prestamo>();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/prestamos"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prestamos = JsonConvert.DeserializeObject<List<Prestamo>>(apiResponse);
                }
            }
            return View(prestamos);
        }

        // GET: Prestamo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Prestamo/Create
        public async Task<ActionResult> Create()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            List<Libro> libros = new List<Libro>();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/estudiantes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(apiResponse);
                    ViewData["Estudiantes"] = new SelectList(estudiantes, "IdLector", "Nombre");
                }

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/libros"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    libros = JsonConvert.DeserializeObject<List<Libro>>(apiResponse);
                    ViewData["Libros"] = new SelectList(libros, "IdLibro", "Titulo");
                }
            }
            return View();

        }

        // POST: Prestamo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Prestamo prestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string stringData = JsonConvert.SerializeObject(prestamo);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {

                        using (var response = await httpClient.PostAsync($"{_configuration["API:Url"]}/api/prestamos", contentData))
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

        // GET: Prestamo/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(LlavePrestamo llave)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            List<Libro> libros = new List<Libro>();
            Prestamo prestamo = new Prestamo();
            try
            {
                using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/estudiantes"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(apiResponse);
                    ViewData["Estudiantes"] = new SelectList(estudiantes, "IdLector", "Nombre");
                }

                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/libros"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    libros = JsonConvert.DeserializeObject<List<Libro>>(apiResponse);
                    ViewData["Libros"] = new SelectList(libros, "IdLibro", "Titulo");
                }
                using (var response = await httpClient.GetAsync($"{_configuration["API:Url"]}/api/prestamos/{llave.IdLibro}/{llave.IdLector}/{llave.FechaPrestamo.ToString("dd-MM-yyyy")}"))
                {
                                          
                        if (!response.IsSuccessStatusCode)
                            throw new Exception("No se encuentra registro");
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        prestamo = JsonConvert.DeserializeObject<Prestamo>(apiResponse);

                    }                  

                }
            }
            catch
            {
                Response.StatusCode = 404;
                return View("_Error");
            }

            return View(prestamo);
        }

        // POST: Prestamo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Prestamo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}