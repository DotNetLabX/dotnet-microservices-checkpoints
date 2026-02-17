using FastEndpoints;
using FluentValidation;
using Journals.Api.Features.Journals.Shared;

namespace Journals.Api.Features.Journals.Search;

public record SearchJournalsQuery(string? Search, int Page = 1, int PageSize = 20);

public record SearchJournalsResponse(
    int Page,
    int PageSize,
    int TotalCount,
    IEnumerable<JournalDto> Items
);

public class SearchJournalsQueryValidator : Validator<SearchJournalsQuery>
{
    public SearchJournalsQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(5, 100);
    }
}
