using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMutual.Scheme
{
    public  class UnprocessableResponse
    {
        public string SchemeId { get; set; }

        public List<UnprocessableErrorsResponse> error { get; set; }
    }

    public class UnprocessableErrorsResponse
    {
        public int Status { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Field { get; set; }
    }
}
