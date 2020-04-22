using AutoMapper;
using JurisTempus.Data;
using JurisTempus.Data.Entities;
using JurisTempus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JurisTempus.Controllers
{
  [ApiController]
  [Route("api/timebills")]
  public class TimeBillsController : ControllerBase
  {
    private readonly ILogger<TimeBillsController> _logger;
    private readonly BillingContext _ctx;
    private readonly IMapper _mapper;

    public TimeBillsController(
      ILogger<TimeBillsController> logger,
      BillingContext ctx,
      IMapper mapper)
    {
      _logger = logger;
      _ctx = ctx;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<TimeBillViewModel[]>> Get()
    {
      var result = await _ctx.TimeBills
        .Include(t => t.Case)
        .Include(t => t.Employee)
        .ToArrayAsync();

      return Ok(_mapper.Map<TimeBill[], TimeBillViewModel[]>(result));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TimeBillViewModel>> Get(int id)
    {
      var result = await _ctx.TimeBills
        .Include(t => t.Case)
        .Include(t => t.Employee)
        .Where(t => t.Id == id)
        .FirstOrDefaultAsync();

      return Ok(_mapper.Map<TimeBill, TimeBillViewModel>(result));
    }

    [HttpPost]
    public async Task<ActionResult<TimeBillViewModel>> Post([FromBody]TimeBillViewModel model)
    {
      var bill = _mapper.Map<TimeBill>(model);

      var theCase = await _ctx.Cases
        .Where(c => c.Id == model.CaseId)
        .FirstOrDefaultAsync();

      var theEmployee = await _ctx.Employees
        .Where(e => e.Id == model.EmployeeId)
        .FirstOrDefaultAsync();

      if (theCase == null || theEmployee == null)
      {
        return BadRequest("Could not find case or employee");
      }

      bill.Case = theCase;
      bill.Employee = theEmployee;

      _ctx.Add(bill);
      if (await _ctx.SaveChangesAsync() > 0)
      {
        return CreatedAtAction("Get", new { id = bill.Id }, _mapper.Map<TimeBillViewModel>(bill));
      }

      return BadRequest("Failed to save new timebill");
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<TimeBill>> Put(int id, [FromBody]TimeBill bill)
    {
      var oldBill = await _ctx.TimeBills
        .Where(b => b.Id == id)
        .FirstOrDefaultAsync();

      if (oldBill == null) return BadRequest("Invalid ID");

      oldBill.Rate = bill.Rate;
      oldBill.TimeSegments = bill.TimeSegments;
      oldBill.WorkDate = bill.WorkDate;
      oldBill.WorkDescription = bill.WorkDescription;

      var theCase = await _ctx.Cases
        .Where(c => c.Id == bill.Case.Id)
        .FirstOrDefaultAsync();

      var theEmployee = await _ctx.Employees
        .Where(e => e.Id == bill.Employee.Id)
        .FirstOrDefaultAsync();

      bill.Case = theCase;
      bill.Employee = theEmployee;

      if (await _ctx.SaveChangesAsync() > 0)
      {
        return Ok(bill);
      }

      return BadRequest("Failed to save new timebill");
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
      var oldBill = await _ctx.TimeBills
        .Where(b => b.Id == id)
        .FirstOrDefaultAsync();

      if (oldBill == null) return NotFound();

      _ctx.Remove(oldBill);

      if (await _ctx.SaveChangesAsync() > 0)
      {
        return Ok();
      }

      return BadRequest("Failed to save new timebill");
    }

  }
}
