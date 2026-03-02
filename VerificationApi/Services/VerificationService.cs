using VerificationApi.Models.DTOModel;
using VerificationApi.Models.EntityModel;
using VerificationApi.Repositories.Interface;
using VerificationApi.Services.Interfaces;


namespace VerificationApi.Services
{
    public class VerificationService : IVerificationService
    {
        private readonly IVerificationRepository _repository;

        public VerificationService(IVerificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<VerificationRequest> CreateVerificationRequestAsync(CreateVerificationRequest dto)
        {
            // 1. Basic validation
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Full name is required");

            if (dto.DocumentFile == null || dto.DocumentFile.Length == 0)
                throw new ArgumentException("Document file is required");

            // 2. Create Uploads folder if not exists
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // 3. Save Document File
            var documentFileName = Guid.NewGuid() + Path.GetExtension(dto.DocumentFile.FileName);
            var documentPath = Path.Combine(uploadsFolder, documentFileName);

            using (var stream = new FileStream(documentPath, FileMode.Create))
            {
                await dto.DocumentFile.CopyToAsync(stream);
            }

            // 4. Save Selfie File (if exists)
            string? selfiePath = null;

            if (dto.SelfieFile != null && dto.SelfieFile.Length > 0)
            {
                var selfieFileName = Guid.NewGuid() + Path.GetExtension(dto.SelfieFile.FileName);
                selfiePath = Path.Combine(uploadsFolder, selfieFileName);

                using (var stream = new FileStream(selfiePath, FileMode.Create))
                {
                    await dto.SelfieFile.CopyToAsync(stream);
                }
            }

            // 5. Create entity
            var request = new VerificationRequest
            {
                FullName = dto.FullName,
                DocumentType = dto.DocumentType,
                DocumentNumber = dto.DocumentNumber,
                DocumentPath = documentPath,
                SelfiePath = selfiePath,
                Status = VerificationStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            // 6. Business Rule Simulation
            request.Status = VerificationStatus.Pending;

            // 7. Save to database
            await _repository.AddAsync(request);
            await _repository.SaveChangesAsync();

            return request;
        }

        public async Task<VerificationRequest> GetByIdAsync(int id)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null)
                throw new KeyNotFoundException("Request not found");
            return request;
        }

        public async Task<VerificationRequest> UpdateStatusAsync(int id, VerificationStatus status)
        {
            var request = await _repository.GetByIdAsync(id);

            if (request == null)
                throw new KeyNotFoundException("Request not found");

            request.Status = status;

            await _repository.SaveChangesAsync();

            return request;
        }

        public async Task<List<VerificationRequest>> GetAllRequestsAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}