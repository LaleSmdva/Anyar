using Business.DTOs.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Auth;

public class RegisterDtoValidator:AbstractValidator<RegisterDto>
{
	public RegisterDtoValidator()
	{
		RuleFor(x => x.Fullname).NotEmpty().NotNull();
	}
}
