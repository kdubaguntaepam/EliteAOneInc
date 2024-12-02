using RestSharp;
using System;

namespace Example.TestAutomation.ExampleTests.AutomationLibrary
{
    public class RequestBuilder
    {
        private readonly IRestRequest _request;

        public RequestBuilder(string resource, Method method)
        {
            _request = new RestRequest(resource, method);
        }

        public RequestBuilder AddJsonBody(object body)
        {
            _request.AddJsonBody(body);
            return this;
        }

        public IRestRequest Build()
        {
            return _request;
        }
    }
}