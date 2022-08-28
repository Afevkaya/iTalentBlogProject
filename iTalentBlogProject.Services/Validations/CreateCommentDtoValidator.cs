using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using iTalentBlogProject.Core.DTOs;

namespace iTalentBlogProject.Services.Validations
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("{PropertyName} null olamaz")
                .NotEmpty().WithMessage("{PropertyName} boş olamaz")
                .MinimumLength(2).WithMessage("{PropertyName} en az 2 karakter olmalıdır")
                .MaximumLength(25).WithMessage("{PropertyName} ez az 50 karakter olmalıdır");

            RuleFor(x => x.Text)
                .NotNull().WithMessage("{PropertyName} null olamaz")
                .NotEmpty().WithMessage("{PropertyName} boş olamaz")
                .MinimumLength(20).WithMessage("{PropertyName} en az 2 karakter içermelidir")
                .MaximumLength(200).WithMessage("{PropertyName} ez az 200 karakter içermelidir.");
        }
    }
}
