using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidtor:AbstractValidator<UpdateReviewCommand>
	{
        public UpdateReviewValidtor()
        {
			RuleFor(x => x.CustomerName).
			   NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!")
			   .MinimumLength(5).WithMessage("Lütfen ismi doğru giriniz");
			RuleFor(y => y.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz!");
			RuleFor(y => y.Comment)
				.NotEmpty().WithMessage("Lütfen yorum boş geçmeyiniz!")
				.MinimumLength(50).WithMessage("Lütfen en az 50 karakter giriniz.")
				.MaximumLength(500).WithMessage("500 karakterden fazla veri giremezsiniz.");
			RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görselini boş geçmeyiniz!");
		}
    }
}
