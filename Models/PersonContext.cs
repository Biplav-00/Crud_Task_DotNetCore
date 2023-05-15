using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace todo_web_app2.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options): base(options)

        {
            
        }

        public DbSet<Person> tbl_Person { get; set; }
        public DbSet<Devices> tbl_Device { get; set; }


        //public string device_
    }
}
