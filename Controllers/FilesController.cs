using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVClab.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Net;

namespace MVClab.Controllers
{
    public class FilesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public FilesController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            //string url = HttpContext.Request.HttpContext.ToString();
            //string url = HttpContext.Request.Host
            //string newPath = Path.GetFullPath(Path.Combine(url,@"..\TextFiles\"));
            string newPath = Path.GetFullPath("../TextFiles/");
            string[] fileswDir = Directory.GetFiles(newPath);
            TextFile[] files = new TextFile[fileswDir.Length];

            for(int i=0; i < fileswDir.Length; i++)
            {
                string result = Path.GetFileName(fileswDir[i]);
                files[i]=new TextFile {file = result, name = result.Substring(0,result.Length-4)};
            }

            ViewBag.title = "File List";

            return View(files);
        }

        public IActionResult content(string id) //content lower case on purpose, Content(string ..) conflicts
        {
            //string wwwroot = _env.WebRootPath;
            //string newPath = Path.GetFullPath(Path.Combine(wwwroot,@"..\TextFiles\",@id+".txt"));
                        string newPath = Path.GetFullPath(Path.Combine("https://comp3973bhlab3.azurewebsites.net/Files",@id+".txt"));
            string content = System.IO.File.ReadAllText(@newPath);
            string[] contentArray = {content, "a"}; //need to pass array

            return View(contentArray);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
