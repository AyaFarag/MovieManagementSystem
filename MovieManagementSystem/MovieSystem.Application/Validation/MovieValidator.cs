using FluentValidation;
using MovieSystem.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.Validation
{
    public class MovieValidator : AbstractValidator<MovieDTO>
    {
        public MovieValidator()
        {
            //RuleFor(m => m.Title).Length(5).WithMessage("Lenght must be 5")
            //    .NotEmpty().WithMessage("ffff").MaximumLength(10).NotNull();
            //RuleFor(d => d.Description).LessThan("20").WithMessage("dddd").NotEqual("50")
            //    .WithMessage("");
        }
    }
}
