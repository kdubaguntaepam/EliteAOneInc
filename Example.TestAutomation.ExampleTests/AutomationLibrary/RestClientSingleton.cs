using RestSharp;
using System;

namespace Example.TestAutomation.ExampleTests.AutomationLibrary
{
    public sealed class RestClientSingleton
    {
        private static readonly Lazy<RestClient> lazy = new Lazy<RestClient>(() => new RestClient());

        public static RestClient Instance { get { return lazy.Value; } }

        private RestClientSingleton()
        {
        }
    }
}