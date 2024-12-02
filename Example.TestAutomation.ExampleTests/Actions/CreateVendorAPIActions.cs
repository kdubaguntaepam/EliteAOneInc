using Example.TestAutomation.ExampleTests.AutomationLibrary;
using RestSharp;
using System;

namespace Example.TestAutomation.ExampleTests.Actions
{
    public class CreateVendorAPIActions
    {
        private readonly RestClient _client;

        public CreateVendorAPIActions()
        {
            _client = RestClientSingleton.Instance;
        }

        public IRestResponse CreateVendor(string businessTIN, string businessSubType)
        {
            var request = new RequestBuilder("heritage_dev/custom/service/v4_1_custom/rest.php", Method.POST)
                .AddJsonBody(new { method = "CreateVendor", input_type = "JSON", response_type = "JSON", rest_data = new { BusinessTIN = businessTIN, BusinessSubType = businessSubType } })
                .Build();

            return _client.Execute(request);
        }
    }
}