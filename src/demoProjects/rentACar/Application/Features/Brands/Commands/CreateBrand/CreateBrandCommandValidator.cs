using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
	public CreateBrandCommandValidator()
	{
		RuleFor(command => command.Name).NotEmpty();
		RuleFor(command => command.Name).MinimumLength(2);
	}
}