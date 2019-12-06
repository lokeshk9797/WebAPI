using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Core3._0.Models;

namespace WebAPI_Core3._0.Data
{
    public class QuoteDBContext : DbContext
    {
        public QuoteDBContext(DbContextOptions<QuoteDBContext> options):base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
