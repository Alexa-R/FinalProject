using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace FinalProject.Helpers
{
    public static class GMailHelper
    {
        private static string[] _scopes = { GmailService.Scope.GmailSend };
        private static string _applicationName = "Gmail API .NET Quickstart";
        private static GmailService _service;

        public static void ConnectToGMailApi()
        {
            UserCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                var credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, _scopes, "Lizy Flower", CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            _service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = _applicationName,
            });
        }

        public static void SendTextMessage()
        {
            ConnectToGMailApi();
            var textMessage = "To: lizy.flower22@gmail.com\r\n" +
                               "Subject: test results\r\n" +
                               "Content-Type: text/html; charset=us-ascii\r\n\r\n" +
                               "<h1>All tests have passed status! </h1>";
            var newMsg = new Message { Raw = Base64UrlEncode(textMessage) };
            _service.Users.Messages.Send(newMsg, "lizy.flower22@gmail.com").Execute();
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);

            return Convert.ToBase64String(inputBytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }
    }
}