using Microsoft.EntityFrameworkCore;
using VerificationApi.Models.EntityModel;
using VerificationApi.Models.DTOModel;

namespace VerificationApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<VerificationRequest> VerificationRequests { get; set; }
    }
}