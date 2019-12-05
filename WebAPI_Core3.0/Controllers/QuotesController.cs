using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Core3._0.Models;

namespace WebAPI_Core3._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        static List<Quote> _quotes = new List<Quote>()
        {
            new Quote(){Id=0,Author="Dr. SC Bose",Description="Give me Blood and I will give you freedom",Title="Freedom"},
            new Quote(){Id=1,Author="Franklin D. Roosevelt",Description="When you reach the end of your rope, tie a knot in it and hang on.",Title="Motivation"},
        };

        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return _quotes;
        }

        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            _quotes.Add(quote);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Quote quote)
        {
            _quotes[id] = quote;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _quotes.RemoveAt(id);

        }
    }
}