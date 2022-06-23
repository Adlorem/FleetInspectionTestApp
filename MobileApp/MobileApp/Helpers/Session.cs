using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MobileApp.Helpers
{
    public static class Session
    {
        public const string ApiEndpoint = "http://10.0.2.2:5186";

        /// <summary>
        /// For testing purposes disable server validation chain for refit client.
        /// </summary>
        /// <returns></returns>
        public static HttpClient UnsafeClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            var httpClient = new HttpClient(httpClientHandler)
            {
                BaseAddress = new Uri(Session.ApiEndpoint)
            };

            return httpClient;
        }
    }
}
