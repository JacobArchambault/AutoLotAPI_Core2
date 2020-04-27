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
        public IActionResult Index()
        {
            return View();
        }
    }
}