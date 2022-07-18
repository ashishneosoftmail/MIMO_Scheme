using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme.Responses
{
    public  class ErrorResponse
    {
        public int  Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
