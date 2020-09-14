using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASPCoreOnGitHub.Controllers
{
    public class HomeController : Controller   // to make it controller you should inherit from Controller Class in  MVC name space
    {
        public string Index()
        {
            return "Hello from MVC contoroller";     
        }


    }
}
