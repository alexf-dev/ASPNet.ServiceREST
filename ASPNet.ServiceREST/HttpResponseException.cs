using System;
using System.Runtime.Serialization;

namespace ASPNet.ServiceREST
{
    [Serializable]
    internal class HttpResponseException : Exception
    {
        private string v;
        private object badRequest;

        public HttpResponseException()
        {
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string v, object badRequest)
        {
            this.v = v;
            this.badRequest = badRequest;
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}