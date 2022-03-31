using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığını boş bırakamazsınız.").Length(5, 150).WithMessage("Blog başlığı 5-150 karakter arasında olmalıdır.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş bırakamazsınız.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş bırakamazsınız.");

        }
    }
}
