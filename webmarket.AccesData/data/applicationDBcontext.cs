using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webmarket.Models;


namespace webmarket.AccesData
{
    
    public class applicationDBcontext: IdentityDbContext
    {
        public applicationDBcontext(DbContextOptions<applicationDBcontext> option):base(option) { }

        
        public DbSet<catigory> categories { get; set; }

        public DbSet<product> products { get; set; }

        public DbSet<company> companys { get; set; }


        public DbSet<shopingcard> shopingcards { get; set; }

        public DbSet<OrderHeader> orderHeaders { get; set; }

        public DbSet<OrderDetails> orderDetails { get; set; }



    }
}
