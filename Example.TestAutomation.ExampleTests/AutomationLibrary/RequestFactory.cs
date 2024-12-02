using RestSharp;
using System;

namespace Example.TestAutomation.ExampleTests.AutomationLibrary
{
    public class RequestFactory
    {
        public static IRestRequest CreateRequest(string resource, Method method, object body = null, DataFormat format = DataFormat.Json)
        {
            var request = new RestRequest(resource, method, format);
            if (body != null)
            {
                request.AddJsonBody(body);
            }
            return request;
        }
    }
}