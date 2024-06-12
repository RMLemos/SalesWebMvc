using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SalesRecord : Controller
{
    private readonly SalesRecordService _salesRecardService;

    public SalesRecord(SalesRecordService salesRecardService)
    {
        _salesRecardService = salesRecardService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
    {
        if (!minDate.HasValue)
        {
            minDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }
        ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        var result = await _salesRecardService.FindByDateAsync(minDate, maxDate);
        return View(result);
    }
    public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
    {
        if (!minDate.HasValue)
        {
            minDate = new DateTime(DateTime.Now.Year, 1, 1);
        }
        if (!maxDate.HasValue)
        {
            maxDate = DateTime.Now;
        }
        ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
        ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
        var result = await _salesRecardService.FindByDateGroupingAsync(minDate, maxDate);
        return View(result);
    }
}

