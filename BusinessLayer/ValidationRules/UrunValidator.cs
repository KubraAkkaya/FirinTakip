using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UrunValidator: AbstractValidator<Urun>
    {
        public UrunValidator()
        {
            RuleFor(x => x.UrunAdi).NotEmpty().WithMessage("Ad kısmını boş geçemezsiniz!");
            RuleFor(x => x.Fiyat).NotEmpty().WithMessage("Fiyat kısmını boş geçemezsiniz!");
            RuleFor(x => x.UrunAdi).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayınız!");
            RuleFor(x => x.UrunAdi).MinimumLength(3).WithMessage("Lütfen 3 karakterden az değer girişi yapmayınız!");
        }

    }
}
