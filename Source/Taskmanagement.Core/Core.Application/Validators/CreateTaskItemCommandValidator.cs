using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Commands;
using FluentValidation;

namespace Core.Application.Validators
{
    public class CreateTaskItemCommandValidator : AbstractValidator<CreateTaskItemCommand>
    {
        public CreateTaskItemCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.DueDate).GreaterThan(DateTime.Now).WithMessage("Due date must be in the future");
            RuleFor(x => x.AssignedUserId).NotEmpty().WithMessage("Assigned user is required");
        }
    }
}
