using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.CQRS.Users.Commands.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.name).NotEmpty();
        RuleFor(x => x.email).NotEmpty().EmailAddress();
        RuleFor(x => x.address).NotEmpty();
        RuleFor(x => x.phone).NotEmpty();
    }
}
