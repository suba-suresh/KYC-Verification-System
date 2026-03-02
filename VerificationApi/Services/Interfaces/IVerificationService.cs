using System;
using VerificationApi.Models.EntityModel;
using VerificationApi.Models.DTOModel;


namespace VerificationApi.Services.Interfaces;

public interface IVerificationService
{
    Task<VerificationRequest> CreateVerificationRequestAsync(CreateVerificationRequest dto);
    Task<VerificationRequest> GetByIdAsync(int id);
    Task<VerificationRequest> UpdateStatusAsync(int id, VerificationStatus status);
    Task<List<VerificationRequest>> GetAllRequestsAsync();

}
