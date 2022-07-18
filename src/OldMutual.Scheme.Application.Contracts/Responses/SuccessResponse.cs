using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme.Responses
{
    public class SuccessResponse
    {
        public string SchemeId { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
