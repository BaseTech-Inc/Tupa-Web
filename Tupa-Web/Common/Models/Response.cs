using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tupa_Web.Common.Models
{
    public class Response<T>
    {
        public Response()
        { }

        public Response(T data, string message = null)
        {
            succeeded = true;
            this.message = message;
            this.data = data;
        }

        public Response(string message)
        {
            succeeded = false;
            this.message = message;
        }

        public bool succeeded { get; set; }
        public string message { get; set; }
        public List<string> errors { get; set; }
        public T data { get; set; }
    }
}