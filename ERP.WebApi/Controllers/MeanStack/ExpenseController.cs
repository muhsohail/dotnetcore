using System.Collections.Generic;
using ERP.Services.MeanStack;
using Microsoft.AspNetCore.Mvc;
using Models.MeanStack;

namespace ERP.WebApi.Controllers.MeanStack
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {

        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public ActionResult<List<Expense>> Get()
        {
            return _expenseService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Expense> Get(string id)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        [HttpPost]
        public ActionResult<Expense> Create(Expense expense)
        {
            _expenseService.Create(expense);

            return CreatedAtRoute("GetBook", new { id = expense.Id.ToString() }, expense);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Expense bookIn)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            _expenseService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var expense = _expenseService.Get(id);

            if (expense == null)
            {
                return NotFound();
            }

            _expenseService.Remove(expense.Id);

            return NoContent();
        }
    }
}