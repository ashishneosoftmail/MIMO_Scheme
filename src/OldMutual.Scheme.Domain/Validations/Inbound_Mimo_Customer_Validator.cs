using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme.Validations
{
    public  class Inbound_Mimo_Customer_Validator : AbstractValidator<Inbound_Scheme_BillGroups>
    {
        public Inbound_Mimo_Customer_Validator()
        {
            RuleFor(x => x.schemeId).NotNull().WithMessage("SchemeId could not be null")
                                    .MaximumLength(20).WithMessage("SchemeId could not be more than 20 chars");

            RuleFor(x => x.system).NotNull().WithMessage("System could not be null")
                                  .MaximumLength(40).WithMessage("SchemeId could not be more than 40 chars");

            RuleFor(x => x.systemCompanyId).NotNull().WithMessage("SystemCompanyId could not be null")
                                           .MaximumLength(40).WithMessage("SystemCompanyId could not be more than 40 chars");

            RuleFor(x => x.systemUniqueId).NotNull().WithMessage("SystemUniqueId could not be null")
                                           .MaximumLength(50).WithMessage("systemUniqueId could not be more than 50 chars");           

            RuleFor(x => x.primaryEmailAddress).MaximumLength(255).WithMessage("EmailAddress could not be more than 255 chars")
                                               .EmailAddress();

            RuleFor(x => x.pinNumber).MaximumLength(10).WithMessage("PinNumber cannot be more than 10 charas");

            RuleFor(x => x.currencyCode).MaximumLength(3).WithMessage("Currency code cannot be more than 3 chars ");

            RuleFor(x => x.partyType).NotNull().WithMessage("PartyType could not be null")
                                          .MaximumLength(20).WithMessage("PartyType could not be more than 20 chars");

            RuleFor(x => x.primaryPhoneNumber).MaximumLength(50).WithMessage("PrimaryPhoneNumber could not be more than 50 chars");

            RuleFor(x => x.addressDefaultRoles).NotNull().WithMessage("addressDefaultRoles could not be null")
                                              .MaximumLength(10).WithMessage("addressDefaultRoles could not be more than 10 chars");

            RuleFor(x => x.addressCountryCode).NotNull().WithMessage("addressCountryCode could not be null")
                                              .MaximumLength(50).WithMessage("addressCountryCode could not be more than 50 chars");

            RuleFor(x => x.brokerCode).MaximumLength(20).WithMessage("brokerCode could not be more than 20 chars");


            RuleForEach(rec => rec.billGroups).NotNull().SetValidator(new BillGroup_Validator());
        }
    }
}
