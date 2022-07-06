using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace OldMutual.Scheme.EntityFrameworkCore
{
    public class SchemeModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public SchemeModelBuilderConfigurationOptions(
            string tablePrefix = SchemeConsts.DbTablePrefix,
             string schema = SchemeConsts.DbSchema)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
