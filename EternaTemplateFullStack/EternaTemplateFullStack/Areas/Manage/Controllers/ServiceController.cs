using EternaTemplateFullStack.Models;
using EternaTemplateFullStack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EternaTemplateFullStack.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ServiceController : Controller
    {
        private readonly DataContext _context;

        public ServiceController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Services = _context.Services.ToList()
            };
            return View(homeVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("index","service");
        }
        public IActionResult Edit(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            Service existService = _context.Services.FirstOrDefault(x=>x.Id == service.Id);
            if (existService == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            existService.Icon = service.Icon;
            existService.Title = service.Title;
            existService.Desc = service.Desc;
            _context.SaveChanges();
            return RedirectToAction("index","service");
        }
        public IActionResult Delete(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            _context.Remove(service);
            _context.SaveChanges();
            return Ok();
        }
    }
}
