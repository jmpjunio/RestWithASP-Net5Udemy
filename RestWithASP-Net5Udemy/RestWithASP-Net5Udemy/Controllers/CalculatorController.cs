using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_Net5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if ((IsNumeric(firstNumber)) && (IsNumeric(secondNumber)))
            {
                var sum = ParseDecimal(firstNumber) + ParseDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invlaid Input");
        }
        [HttpGet("debt/{firstNumber}/{secondNumber}")]
        public IActionResult Debt(string firstNumber, string secondNumber)
        {
            if ((IsNumeric(firstNumber)) && (IsNumeric(secondNumber)))
            {
                var sum = ParseDecimal(firstNumber) / ParseDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invlaid Input");
        }
        [HttpGet("multiply/{firstNumber}/{secondNumber}")]
        public IActionResult Multiply(string firstNumber, string secondNumber)
        {
            if ((IsNumeric(firstNumber)) && (IsNumeric(secondNumber)))
            {
                var sum = ParseDecimal(firstNumber) * ParseDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invlaid Input");
        }
        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if ((IsNumeric(firstNumber)) && (IsNumeric(secondNumber)))
            {
                var sum = ParseDecimal(firstNumber) - ParseDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invlaid Input");
        }

        private bool IsNumeric(string valor)
        {
            double number;
            bool isNumber = double.TryParse(
                valor,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        private decimal ParseDecimal(string valor)
        {
            decimal decimalValue;
            if (decimal.TryParse(valor, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        
    }
}
