using Microsoft.EntityFrameworkCore;
using ssoapi.Models;

namespace ssoapi.Data {
    
    public class SSOContext : DbContext {
        
        public SSOContext(DbContextOptions<SSOContext> options) : base(options) {



        }

        public DbSet<Horse> Horses { get; set; } // Horses DB
        public DbSet<Note> Notes { get; set; } // Notes DB
        public DbSet<News> News { get; set; } // News DB

    }

}