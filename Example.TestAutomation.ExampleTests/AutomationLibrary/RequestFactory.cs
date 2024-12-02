using RestSharp;
using System;

namespace Example.TestAutomation.ExampleTests.AutomationLibrary
{
    public class RequestFactory
    {
        public static IRestRequest CreateRequest(string resource, Method method, DataFormat dataFormat = DataFormat.Json)
        {
            var request = new RestRequest(resource, method, dataFormat);
            return request;
        }
    }
}