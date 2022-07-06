
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OldMutual.Scheme
{
    public  class Inbound_Mimo_Customer : Entity<Guid>
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
        public string primaryPhoneNumber { get; set;}

        [Required]
        [StringLength(10)]
        public string addressDefaultRoles { get; set; }

        [Required]
        [StringLength(50)]
        public string addressCountryCode { get; set; }

     
        public bool billGroupCombinedCollection { get; set; }

        public string brokerCode{ get; set; }




        //-----------------------------------------------------//
        
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



        //public CustomerScheme(Guid Id ,string  schemeid, string system, string systemCompanyId, string systemUniqueId, string customerGroupId, string primaryEmailAddress, string pinNumber, string currencyCode, string partyType, string primaryPhoneNumber, string addressDefaultRoles, string addressCountryCode, bool billGroupCombinedCollection, string brokerCode, bool isBillGroup, string billGroupNo, string billGroupName, bool brokerCombinedCollection, string customerBankAccountHolder, string customerBankAccountNumber, string customerBankBranchCode, string customerBankName, string customerCellularAccountNumber, string customerExternalMethodOfPayment, string iBanNo, string addressDescription) 
        //{
        //}
        private Inbound_Mimo_Customer()
        {
            
        }

        internal Inbound_Mimo_Customer(
              Guid id
            , string schemeid
            , string system
            , string systemCompanyId
            , string systemUniqueId
            , string customerGroupId
            , string primaryEmailAddress
            , string pinNumber
            , string currencyCode
            , string partyType
            , string primaryPhoneNumber
            , string addressDefaultRoles
            , string addressCountryCode
            , bool billGroupCombinedCollection
            , string brokerCode
            , bool isBillGroup
            , string billGroupNo
            , string billGroupName
            , bool brokerCombinedCollection
            , string customerBankAccountHolder
            , string customerBankAccountNumber
            , string customerBankBranchCode
            , string customerBankName
            , string customerCellularAccountNumber
            , string customerExternalMethodOfPayment
            , string iBanNo
            , string addressDescription
            )
        {
            Id = id;
            this.schemeId = schemeid;
            this.system = system;
            this.systemCompanyId = systemCompanyId;
            this.systemUniqueId = systemUniqueId;
            this.customerGroupId = customerGroupId;
            this.primaryEmailAddress = primaryEmailAddress;
            this.pinNumber = pinNumber;
            this.currencyCode = currencyCode;
            this.partyType = partyType;
            this.primaryPhoneNumber = primaryPhoneNumber;
            this.addressDefaultRoles = addressDefaultRoles;
            this.addressCountryCode = addressCountryCode;
            this.brokerCombinedCollection = brokerCombinedCollection;
            this.brokerCode = brokerCode;
            this.isBillGroup = isBillGroup;
            this.billGroupNo = billGroupNo;
            this.billGroupName = billGroupName;
            this.billGroupCombinedCollection = billGroupCombinedCollection;
            this.customerBankAccountHolder = customerBankAccountHolder;
            this.customerBankAccountNumber = customerBankAccountNumber;
            this.customerBankBranchCode = customerBankBranchCode;
            this.customerBankName = customerBankName;
            this.customerCellularAccountNumber = customerCellularAccountNumber;
            this.customerExternalMethodOfPayment = customerExternalMethodOfPayment;
            this.iBanNo = iBanNo;
            this.addressDescription = addressDescription;


        }


    }
}
