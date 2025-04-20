using FluentValidation;

namespace MinimalApi.Extensions.Example.Dtos;

public class Cat
{
    public string Name { get; set; }
}

public class CatValidator : AbstractValidator<Cat>
{
    public CatValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(8);
    }
}