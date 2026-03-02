using Microsoft.EntityFrameworkCore;
using VerificationApi.Data;
using VerificationApi.Models.EntityModel;
using VerificationApi.Repositories.Interface;

namespace VerificationApi.Repositories
{
    public class VerificationRepository : IVerificationRepository
    {
        private readonly AppDbContext _context;

        public VerificationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(VerificationRequest request)
        {
            await _context.VerificationRequests.AddAsync(request);
        }

        public async Task<VerificationRequest?> GetByIdAsync(int id)
        {
            return await _context.VerificationRequests
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VerificationRequest>> GetAllAsync()
        {
            return await _context.VerificationRequests
                                 .OrderByDescending(x => x.CreatedAt)
                                 .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}