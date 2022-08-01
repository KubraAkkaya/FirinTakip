using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MusteriValidator: AbstractValidator<Musteri>
    {
        public MusteriValidator()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad kısmını boş geçemezsiniz!");
            RuleFor(x => x.Adresi).NotEmpty().WithMessage("Adres kısmını boş geçemezsiniz!");
            RuleFor(x => x.Ad).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız!");
            RuleFor(x => x.Ad).MinimumLength(3).WithMessage("Lütfen 3 karakterden az değer girişi yapmayınız!");
        }
    }
}
