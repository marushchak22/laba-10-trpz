// Controllers/BicycleController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using YourNamespace.Models;


public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var brands = _context.BrandType
            .Select(bt => new
            {
                bt.BrandTypeID,          
                bt.BrandName,         
                bt.Country,             
                BicycleTypeName = bt.BicycleType.TypeName 
            })
            .ToList();

        return View(brands);
    }



    public IActionResult Details(int id)
    {
        var bicycleType = _context.BicycleType
            .FirstOrDefault(bt => bt.BicycleTypeID == id);

        if (bicycleType == null)
        {
            return NotFound();
        }

        return View(bicycleType);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
        base.Dispose(disposing);
    }


	public IActionResult Create()
	{
		ViewBag.BicycleType = new SelectList(_context.BicycleType.ToList(), "BicycleTypeID", "TypeName");
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(BrandType brandType)
	{
		if (ModelState.IsValid)
		{
			_context.BrandType.Add(brandType);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		ViewBag.BicycleType = new SelectList(_context.BicycleType.ToList(), "BicycleTypeID", "TypeName");
		return View(brandType);
	}





    public IActionResult Edit(int id)
    {
        var brandType = _context.BrandType.Find(id);
        if (brandType == null)
        {
            return NotFound();
        }

        ViewBag.BicycleType = new SelectList(_context.BicycleType.ToList(), "BicycleTypeID", "TypeName", brandType.BicycleTypeID);

        return View(brandType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, BrandType brandType)
    {
        if (id != brandType.BrandTypeID)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            _context.Update(brandType);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.BicycleType = new SelectList(_context.BicycleType.ToList(), "BicycleTypeID", "TypeName", brandType.BicycleTypeID);

        return View(brandType);
    }



    public IActionResult Delete(int id)
    {
        var brandType = _context.BrandType
            .Include(bt => bt.BicycleType)
            .FirstOrDefault(bt => bt.BrandTypeID == id);

        if (brandType == null)
        {
            return NotFound();
        }

        return View(brandType);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var brandType = _context.BrandType.Find(id);
        if (brandType != null)
        {
            _context.BrandType.Remove(brandType);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }


}
=