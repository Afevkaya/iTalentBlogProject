using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using iTalentBlogProject.Core.DTOs;

namespace iTalentBlogProject.Services.Validations
{
    public class CreatePostDtoValidator: AbstractValidator<CreatePostDto>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(x => x.Article)
                .NotNull().WithMessage("{PropertyName} null olamaz")
                .NotEmpty().WithMessage("{PropertyName} boş olamaz")
                .MinimumLength(50).WithMessage("{PropertyName} en az 50 karakter içermelidir");
            
            RuleFor(x => x.PhotoUrl)
                .NotNull().WithMessage("{PropertyName} null olamaz")
                .NotEmpty().WithMessage("{PropertyName} boş olamaz");
            
            RuleFor(x=>x.Title)
                .NotNull().WithMessage("{PropertyName} null olamaz")
                .NotEmpty().WithMessage("{PropertyName} boş olamaz")
                .MinimumLength(5).WithMessage("{PropertyName} en az 5 karakter içermelidir")
                .MaximumLength(50).WithMessage("{PropertyName} en fazla 50 karakter içermelidir"); ;
        }
    }
}
