using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using minirestuarent.Models;
using minirestuarent.Data;

namespace minirestuarent.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDBContext _db;
    public CategoryController(ApplicationDBContext db){
        _db = db;
    }
   public IActionResult Index()
    {
        List<Category> objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if(obj.Name = obj.DisplayOrder.ToString()){
            ModelState.AddModelError("name", "The Dispaly Order cann't exactly match the name")
        }
        if(ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}