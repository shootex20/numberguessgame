using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberguess.Controllers
{
    [ApiController]
    [Route("api/numbers")]
    public class NumbersController : ControllerBase
    {
        private readonly ILogger<NumbersController> _logger;

        public NumbersController(ILogger<NumbersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IEnumerable<Numbers> Post(int low, int high)
        {
            if (low > high) {
                int temp = low;
                low = high;
                high = temp;
            }
            return Get(low, high);

        }

        [HttpGet]
        public IEnumerable<Numbers> Get(int low, int high)
        {
            var rng = new Random();

            int firstGen = rng.Next(low, high);
            int secondGen = rng.Next(low, high);

            //Checks so we do not get negative values.
            if (firstGen <= secondGen)
            {
                int temp = secondGen;
                secondGen = firstGen;
                firstGen = temp;
            }

            yield return new Numbers(firstGen, secondGen, firstGen + secondGen, "");
        }
    }
}
