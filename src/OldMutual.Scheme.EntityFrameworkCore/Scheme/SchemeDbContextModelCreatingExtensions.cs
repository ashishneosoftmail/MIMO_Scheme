using Microsoft.EntityFrameworkCore;
using OldMutual.Scheme.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace OldMutual.Scheme.Scheme
{
    public static class SchemeDbContextModelCreatingExtensions
    {
        public static void ConfigureSchemeManagement(
            this ModelBuilder builder,
            Action<SchemeModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new SchemeModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Inbound_Mimo_Customer>(b =>
            {
                b.ToTable(options.TablePrefix + "Inbound_Mimo_Customer", options.Schema);

                //b.ConfigureConcurrencyStamp();
                //b.ConfigureExtraProperties();
                //b.ConfigureAudited();

                b.Property(x => x.schemeId);
                b.Property(x => x.system);
                b.Property(x => x.systemCompanyId);
                b.Property(x => x.systemUniqueId);
                b.Property(x => x.customerGroupId);
                b.Property(x => x.primaryEmailAddress);
                b.Property(x => x.pinNumber);
                b.Property(x => x.currencyCode);
                b.Property(x => x.partyType);
                b.Property(x => x.primaryPhoneNumber);
                b.Property(x => x.addressDefaultRoles);
                b.Property(x => x.addressCountryCode);
                b.Property(x => x.billGroupCombinedCollection);
                b.Property(x => x.brokerCode);
                b.Property(x => x.isBillGroup);
                b.Property(x => x.billGroupNo);
                b.Property(x => x.billGroupName);
                b.Property(x => x.brokerCombinedCollection);
                b.Property(x => x.customerBankAccountHolder);
                b.Property(x => x.customerBankAccountNumber);
                b.Property(x => x.customerBankBranchCode);
                b.Property(x => x.customerBankName);
                b.Property(x => x.customerCellularAccountNumber);
                b.Property(x => x.customerExternalMethodOfPayment);
                b.Property(x => x.iBanNo);
                b.Property(x => x.addressDescription);

            });


        }
    }
}

