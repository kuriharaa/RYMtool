using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RYMtool.Core.Dtos.Responses
{
    public class Response
    {
        public HttpStatusCode Code { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
