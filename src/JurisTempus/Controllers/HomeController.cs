using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JurisTempus.Data;
using Microsoft.EntityFrameworkCore;
using JurisTempus.ViewModels;
using AutoMapper;
using JurisTempus.Data.Entities;

namespace JurisTempus.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly BillingContext _context;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, BillingContext context, IMapper mapper)
    {
      _logger = logger;
      _context = context;
      _mapper = mapper;
    }

    public IActionResult Index()
    {
      var result = _context.Clients
                  .Include(c => c.Address)
                  .Include(c=> c.Cases)
                  //.Select(c => new ClientViewModel()
                  //{
                  //    Id = c.Id,
                  //    Name = c.Name,
                  //    ContactName = c.Contact,
                  //    Phone = c.Phone
                  //})
                  .ToArray();

      var vms = _mapper.Map<Client[], ClientViewModel[]>(result);

      return View(vms);
    }

    [HttpGet("editor/{id:int}")]
    public async Task<IActionResult> ClientEditor(int id)
    {
      var result = await _context.Clients
        .Include(c => c.Address)
        .Where(c => c.Id == id)
        .FirstOrDefaultAsync();

      return View(result);
    }

    [HttpGet("timesheet")]
    public IActionResult Timesheet()
    {
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
