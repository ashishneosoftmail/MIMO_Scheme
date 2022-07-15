using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme
{
    public class Inbound_Scheme_BillGroups
    {
        public string schemeId { get; set; }

        public string system { get; set; }

        public string systemCompanyId { get; set; }

        public string systemUniqueId { get; set; }

        public string primaryEmailAddress { get; set; }

        public string pinNumber { get; set; }

        public string currencyCode { get; set; }

        public string partyType { get; set; }

        public string primaryPhoneNumber { get; set; }

        public string addressDefaultRoles { get; set; }

        public string addressCountryCode { get; set; }

        public bool brokerCombinedCollection { get; set; }

        public string brokerCode { get; set; }

        public List<BillGroups> billGroups { get; set; }

    }
    public class BillGroups
    {
        public bool isBillGroup { get; set; }

        public string billGroupNo { get; set; }

        public string billGroupName { get; set; }

        public bool billGroupCombinedCollection { get; set; }

        public string customerGroupId { get; set; }

        public string customerBankAccountHolder { get; set; }

        public string customerBankAccountNumber { get; set; }

        public string customerBankBranchCode { get; set; }

        public string customerBankName { get; set; }

        public string customerCellularAccountNumber { get; set; }

        public string customerExternalMethodOfPayment { get; set; }

        public string iBanNo { get; set; }

        public string addressDescription { get; set; }
    }
}
