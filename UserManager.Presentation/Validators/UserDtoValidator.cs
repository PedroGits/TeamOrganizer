using FluentValidation;
using System.Collections.Generic;
using System.ComponentModel;
using UserManager.Application.DTOs;

namespace UserManager.Presentation.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDTO>
    {
        public UserDtoValidator()
        {
            RuleFor(user => user.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(user => user.Role)
                .IsInEnum().WithMessage("Role must be either Admin or User.");

            RuleFor(user => user.IsActive)
                .NotNull().WithMessage("IsActive status must be specified.");

            RuleFor(user => user.Password)
                           .NotEmpty().WithMessage("Password is required.")
                           .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                           .MaximumLength(10).WithMessage("Password must not exceed 10 characters.")
                           .Matches(@"[0-9]").WithMessage("Password must contain at least one number.");
        }
    }
}
