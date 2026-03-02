using System;

namespace VerificationApi.Models.EntityModel;

public class VerificationRequest
{
    public int Id { get; set; }

    public required string FullName { get; set; }
    public required string DocumentType { get; set; }

    public string? DocumentNumber { get; set; }

    // NEW: Store file paths instead of URL
    public string? DocumentPath { get; set; }
    public string? SelfiePath { get; set; }

    public VerificationStatus Status { get; set; } = VerificationStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public enum VerificationStatus
{
    Pending = 0,
    Approved = 1,
    Rejected = 2,
}