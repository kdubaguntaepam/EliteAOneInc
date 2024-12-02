using RestSharp;
using System;

namespace Example.TestAutomation.ExampleTests.AutomationLibrary
{
    public class RequestBuilder
    {
        private readonly IRestRequest _request;

        public RequestBuilder(string resource, Method method, DataFormat dataFormat = DataFormat.Json)
        {
            _request = new RestRequest(resource, method, dataFormat);
        }

        public RequestBuilder AddParameter(string name, object value)
        {
            _request.AddParameter(name, value);
            return this;
        }

        public RequestBuilder AddHeader(string name, string value)
        {
            _request.AddHeader(name, value);
            return this;
        }

        public IRestRequest Build()
        {
            return _request;
        }
    }
}