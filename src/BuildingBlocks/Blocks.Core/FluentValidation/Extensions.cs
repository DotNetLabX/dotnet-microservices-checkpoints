using Blocks.Core;
using FluentValidation;

namespace Blocks.FluentValidation;

public static class Extensions
{
    public static IRuleBuilderOptions<T, TProperty> WithMessageForInvalidId<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string propertyName)
        => rule.WithMessage(c => ValidationMessages.InvalidId.FormatWith(propertyName));

    public static IRuleBuilderOptions<T, TProperty> NotEmptyWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string propertyName)
           => ruleBuilder
               .NotEmpty()
               .WithMessage(c => ValidationMessages.NullOrEmptyValue.FormatWith(propertyName));

    public static IRuleBuilderOptions<T, string?> MaximumLengthWithMessage<T>(this IRuleBuilder<T, string?> ruleBuilder, int maxLength, string propertyName)
        => ruleBuilder
            .MaximumLength(maxLength)
            .WithMessage(c => ValidationMessages.MaxLengthExceeded.FormatWith(propertyName, maxLength));

    public static IRuleBuilderOptions<T, TProperty> NotNullWithMessage<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        => ruleBuilder
            .NotNull()
            .WithMessage(c => ValidationMessages.NullOrEmptyValue.FormatWith(typeof(TProperty).Name));


}
