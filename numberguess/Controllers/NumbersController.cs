using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace numberguess.Controllers
{
    public class NumbersController : ControllerBase
    {
        private readonly ILogger<NumbersController> _logger;

        public NumbersController(ILogger<NumbersController> logger)
        {
            _logger = logger;
        }

        [HttpPost, Route("api/numbers/addition")]
        public IEnumerable<Numbers> Addition(int low, int high)
        {
            if (low > high) {
                int temp = low;
                low = high;
                high = temp;
            }
            return GetNumbersAddition(low, high);

        }

        public IEnumerable<Numbers> GetNumbersAddition(int low, int high)
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

        [HttpPost, Route("api/numbers/subtraction")]
        public IEnumerable<Numbers> Subtraction(int low, int high)
        {
            if (low > high)
            {
                int temp = low;
                low = high;
                high = temp;
            }
            return GetNumbersSubtraction(low, high);

        }

        public IEnumerable<Numbers> GetNumbersSubtraction(int low, int high)
        {
            var rng = new Random();

            int firstGen = rng.Next(low, high);
            int secondGen = rng.Next(low, high);

            //Checks so we do not get negative values.
            if (firstGen < secondGen)
            {
                int temp = secondGen;
                secondGen = firstGen;
                firstGen = temp;
            }

            yield return new Numbers(firstGen, secondGen, firstGen - secondGen, "");
        }

        [HttpPost, Route("api/numbers/multiplication")]
        public IEnumerable<Numbers> Multiplication(int low, int high)
        {
            if (low > high)
            {
                int temp = low;
                low = high;
                high = temp;
            }
            return GetNumbersMultiplication(low, high);

        }

        public IEnumerable<Numbers> GetNumbersMultiplication(int low, int high)
        {
            var rng = new Random();

            int firstGen = rng.Next(low, high);
            int secondGen = rng.Next(low, high);


            yield return new Numbers(firstGen, secondGen, firstGen * secondGen, "");
        }
        /* WIP
        [HttpPost, Route("api/numbers/division")]
        public IEnumerable<Numbers> Division(int low, int high)
        {
            if (low > high)
            {
                int temp = low;
                low = high;
                high = temp;
            }
            return GetNumbersDivision(low, high);

        }

        public IEnumerable<Numbers> GetNumbersDivision(int low, int high)
        {
            var rng = new Random();

            int firstGen = rng.Next(low, high);
            int secondGen = rng.Next(low, high);

            if (firstGen < secondGen)
            {
                int temp = secondGen;
                secondGen = firstGen;
                firstGen = temp;
            }

            double div = firstGen / secondGen;

            double test = Math.Round(div, 2);
             
            yield return new Numbers(firstGen, secondGen, (int) test, "");
        }
        */
    }
}
