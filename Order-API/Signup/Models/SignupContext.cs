using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Models
{
    public class SignupContext : DbContext
    {
        public SignupContext(DbContextOptions<SignupContext> options) : base(options)
        {

        }
        public DbSet<Signup> Signups { get; set; }
    }
}