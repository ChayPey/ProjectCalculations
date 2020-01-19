using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectCalculations.Models;

namespace ProjectCalculations.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(PressureLossCalculation.InputModel data)
        {
            //KeepData.Result.InputModels.Clear();
            try
            {
                KeepData.Results.Remove(data.Id);
            }
            catch
            {

            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InputPage(PressureLossCalculation.InputModel data)
        {
            //
            if(data.Id == 0)
            {
                data.Id = KeepData.CountId;
                KeepData.CountId++;
                KeepData.Results.Add(data.Id, new ResultCalcul());
                KeepData.Results[data.Id].id = data.Id;
            }
            //
            PressureLossCalculation.Calculation calculation = new PressureLossCalculation.Calculation(data);
            calculation.Count();
            KeepData.Results[data.Id].InputModels.Add(calculation.Result());
            return View(data);
        }

        public IActionResult ResultPage(PressureLossCalculation.InputModel data)
        {
            PressureLossCalculation.Calculation calculation = new PressureLossCalculation.Calculation(data);
            calculation.Count();
            KeepData.Results[data.Id].InputModels.Add(calculation.Result());
            return View(KeepData.Results[data.Id]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        // хранение результатов рачетов
    }
}
