using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme.Validations
{
    public class BillGroup_Validator : AbstractValidator<BillGroups>
    {
        public BillGroup_Validator()
        {
            RuleFor(x => x.billGroupNo).MaximumLength(20).WithMessage("billGroupNo could not be more than 20 chars");

            RuleFor(x => x.billGroupName).MaximumLength(200).WithMessage("BillGroupName could not be more than 200 chars");

            RuleFor(x => x.billGroupCombinedCollection).NotNull().WithMessage("BillGroupCombinedCollection could not be null");

            RuleFor(x => x.customerGroupId).NotNull().WithMessage("CustomerGroupId could not be null")
                                           .MaximumLength(10).WithMessage("customerGroupId could not be more than 10 chars");

            RuleFor(x => x.customerBankAccountHolder).NotNull().WithMessage("CustomerBankAccountHolder could not be null")
                                                 .MaximumLength(60).WithMessage("CustomerBankAccountHolder could not be more than 60 chars");

            RuleFor(x => x.customerBankAccountNumber).NotNull().WithMessage("CustomerBankAccountNumber could not be null")
                                                 .MaximumLength(48).WithMessage("CustomerBankAccountNumber could not be more than 48 chars");

            RuleFor(x => x.customerBankBranchCode).NotNull().WithMessage("CustomerBankBranchCode could not be null")
                                                 .MaximumLength(12).WithMessage("CustomerBankBranchCode could not be more than 12 chars");

            RuleFor(x => x.customerBankName).NotNull().WithMessage("CustomerBankName could not be null")
                                                 .MaximumLength(60).WithMessage("CustomerBankName could not be more than 60 chars");

            RuleFor(x => x.customerCellularAccountNumber).MaximumLength(20).WithMessage("CustomerCellularAccountNumber could not be more than 20 chars");

            RuleFor(x => x.customerExternalMethodOfPayment).NotNull().WithMessage("CustomerExternalMethodOfPayment could not be null")
                                                 .MaximumLength(20).WithMessage("CustomerExternalMethodOfPayment could not be more than 20 chars");

            RuleFor(x => x.iBanNo).MaximumLength(48).WithMessage("iBanNo could not be more than 48 chars");

            RuleFor(x => x.addressDescription).NotNull().WithMessage("addressDescription could not be null")
                                                 .MaximumLength(60).WithMessage("addressDescription could not be more than 60 chars");
        }
    }
}
