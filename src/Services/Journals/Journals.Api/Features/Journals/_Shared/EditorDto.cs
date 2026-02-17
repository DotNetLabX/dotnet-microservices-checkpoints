using Journals.Domain.Journals.Enums;

namespace Journals.Api.Features.Journals.Shared;

public record EditorDto(
    int Id,
    string FullName,
    string Affiliation, 
    EditorRole Role = EditorRole.ChiefEditor);
