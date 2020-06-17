using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _db;
        public int PicId = 1;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _db = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _db.Users.ToListAsync());
        }
        public IActionResult AddPicture()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile uploadPicture)
        {
            BinaryReader reader = new BinaryReader(uploadPicture.OpenReadStream());
            byte[] picData = reader.ReadBytes((int)uploadPicture.Length);
            User user = _db.Users.First(u => u.Id == PicId);
            Picture pic = new Picture { Image = picData,User=user};      
            //_db.Users.FirstOrDefault(u => u.Id == PicId).Pictures.Add(pic);
            _db.Pictures.Add(pic);
            await _db.SaveChangesAsync();
            PicId++;
            return View();
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
