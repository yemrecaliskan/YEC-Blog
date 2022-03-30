using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez.").Length(2,50).WithMessage("Yazar adı 2-50 karakter arasında olmalıdır.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.").When(x => !string.IsNullOrEmpty(x.WriterMail));
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Bırakılamaz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.WriterPassword).Equal(x => x.WriterPasswordAgain).WithMessage("Şifreler eşleşmiyor");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf, bir büyük harf ve rakam içermelidir.");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Lütfen geçerli bir dosya yolu girin.");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
