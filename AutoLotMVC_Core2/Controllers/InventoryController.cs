using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoLotDAL_Core2.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AutoLotMVC_Core2.Controllers
{
    public class InventoryController : Controller
    {
        public readonly string _baseUrl;
        public InventoryController(IConfiguration configuration)
        {
            _baseUrl = configuration.GetSection("ServiceAddress").Value;
        }
        public async Task<IActionResult> Index()
        {
            return View("IndexWithViewComponent");
        }
        private async Task<Inventory> GetInventoryRecord(int id)
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"{_baseUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var inventory = JsonConvert.DeserializeObject<Inventory>(await response.Content.ReadAsStringAsync());
                return inventory;
            }
            return null;
        }
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var inventory = await GetInventoryRecord(id.Value);
            return inventory != null ? (IActionResult)View(inventory) : NotFound();
        }
    }
}