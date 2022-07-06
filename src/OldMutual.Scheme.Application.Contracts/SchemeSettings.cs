using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme.Application.Contracts
{
    public static class SchemeSettings
    {
        public const string GroupName = "Scheme";

        /// <summary>
        /// Maximum allowed page size for paged list requests.
        /// </summary>
        public const string MaxPageSize = GroupName + ".MaxPageSize";
    }
}
