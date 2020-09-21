using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestASPCoreOnGitHub.Controllers
{
    public class HomeController : Controller   // to make it controller you should inherit from Controller Class in  MVC name space
    {
        public ViewResult Index()
        {
            //return View();   // if the name of action the same name of view so you need  only call  View function and that will response with
                             // view with same name 

            // or if the name of view different from controller name you should pass name of view as string in View('name of view','model name ')  
            var obj =new   { id = 1, name = "ibrahim" };
            // return  View("AboutUs", obj);
            return View();
        }

        public ViewResult AboutUs()
        {
            return View("Index");
        }

        public ViewResult ContactUs()
        {
            return View();
        }


        public ViewResult FullPathView()
        {
            // fullpath 
            return View("~/TempView/IbrahimTemp.cshtml");

            // relative path 
            // where the defulat path on Views folder --> Home Folder --> index.cshtml 
            // so the relative is back two folders and go to TempView /  ibrahimtemp
            // and here you don't need to use cshtml extension
            //return View("../../TempView/IbrahimTemp");
        }



        public ViewResult Careers()
        {
            return View();
        }


    }
}
