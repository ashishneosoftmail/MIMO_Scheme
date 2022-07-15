using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme
{
    public  class BadRequestResponse
    {
        public string SchemeId { get; set; }
        public BadRequestErrorsResponse error { get; set; }      
    }

    public class BadRequestErrorsResponse
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }       
    }

}
