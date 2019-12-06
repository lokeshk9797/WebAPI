using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Core3._0.Data;
using WebAPI_Core3._0.Models;

namespace WebAPI_Core3._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        readonly QuoteDBContext _quoteDBContext ;
        public QuotesController(QuoteDBContext quoteDBContext)
        {
            _quoteDBContext = quoteDBContext;
        }

        // GET: api/Quotes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_quoteDBContext.Quotes);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quoteFromDB = _quoteDBContext.Quotes.Find(id);
            if(quoteFromDB==null)
            {
                return NotFound("No value found against this ID..");
            }
            return Ok(quoteFromDB);
        }

        // POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote  quote)
        {
            _quoteDBContext.Quotes.Add(quote);
            _quoteDBContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
            
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var quoteFromDB = _quoteDBContext.Quotes.Find(id);
            if(quoteFromDB==null)
            {
                return NotFound("No value found against this ID..");
            }
            quoteFromDB.Title = quote.Title;
            quoteFromDB.Author   = quote.Author;
            quoteFromDB.Description = quote.Description;
            _quoteDBContext.SaveChanges();
            return Ok("Record Updated Sucessfully");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quoteFromDB = _quoteDBContext.Quotes.Find(id);
            if(quoteFromDB==null)
            {
                return NotFound("No value found against this ID..");
            }
            _quoteDBContext.Quotes.Remove(quoteFromDB);
            _quoteDBContext.SaveChanges();
            return Ok("Quote Deleted");
        }
    }
}
