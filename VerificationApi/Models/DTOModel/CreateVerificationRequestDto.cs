using Microsoft.AspNetCore.Http;

namespace VerificationApi.Models.DTOModel;

public class CreateVerificationRequest
{
    public required string FullName { get; set; }
    public required string DocumentType { get; set; }
    public required string DocumentNumber { get; set; }

    public IFormFile DocumentFile { get; set; } = null!;
    public IFormFile? SelfieFile { get; set; }
}