using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using minirestuarent.Models;

namespace minirestuarent.Controllers;

public class CategoryController : Controller
{
   public string Index()
    {
        return "This is my default action...";
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public string Welcome()
    {
        return "This is the Welcome action method...";
    }
}