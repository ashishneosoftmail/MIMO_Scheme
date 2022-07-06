using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OldMutual.Scheme
{
    public class CreateInbound_Mimo_CustomerDto : Entity<Guid>
    {
        [Key]
        [Required]
        [StringLength(40)]
        public string schemeId { get; set; }

        [Required]
        [StringLength(40)]
        public string system { get; set; }

        [Required]
        [StringLength(40)]
        public string systemCompanyId { get; set; }

        [Required]
        [StringLength(50)]
        public string systemUniqueId { get; set; }

        [Required]
        [StringLength(10)]
        public string customerGroupId { get; set; }

        [Required]
        [StringLength(255)]
        public string primaryEmailAddress { get; set; }


        [StringLength(20)]
        public string pinNumber { get; set; }

        [StringLength(3)]
        public string currencyCode { get; set; }

        [Required]
        [StringLength(20)]
        public string partyType { get; set; }

        [StringLength(255)]
        public string primaryPhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string addressDefaultRoles { get; set; }

        [Required]
        [StringLength(50)]
        public string addressCountryCode { get; set; }


        public bool billGroupCombinedCollection { get; set; }


        public string brokerCode { get; set; }

        [Required]
        public bool isBillGroup { get; set; }


        [StringLength(20)]
        public string billGroupNo { get; set; }


        [StringLength(100)]
        public string billGroupName { get; set; }

        public bool brokerCombinedCollection { get; set; }

        [Required]
        [StringLength(60)]
        public string customerBankAccountHolder { get; set; }

        [Required]
        [StringLength(48)]
        public string customerBankAccountNumber { get; set; }


        [Required]
        [StringLength(12)]
        public string customerBankBranchCode { get; set; }

        [Required]
        [StringLength(60)]
        public string customerBankName { get; set; }

        [StringLength(20)]
        public string customerCellularAccountNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string customerExternalMethodOfPayment { get; set; }

        [StringLength(48)]
        public string iBanNo { get; set; }

        [Required]
        [StringLength(60)]
        public string addressDescription { get; set; }

    }
}
