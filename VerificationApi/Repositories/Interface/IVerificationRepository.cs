using System;
using VerificationApi.Models.EntityModel;
using VerificationApi.Models.DTOModel;

namespace VerificationApi.Repositories.Interface;


public interface IVerificationRepository
{
    Task AddAsync(VerificationRequest entity);
    Task<VerificationRequest?> GetByIdAsync(int id);
    Task<List<VerificationRequest>> GetAllAsync();
    Task SaveChangesAsync();
}

