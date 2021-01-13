using System;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Demo.FCM.Backend
{
    public class FirebaseCloudMessaging : IFirebaseCloudMessaging
    {
        public readonly FirebaseMessaging FirebaseMessagingInstance;
        private const string CredentialsJsonString = "";

        public FirebaseCloudMessaging()
        {
            FirebaseMessagingInstance = GetInstance();
        }

        private static FirebaseMessaging GetInstance()
        {
            var firebaseApp = FirebaseAdmin.FirebaseApp.GetInstance("[Default]") ?? FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(CredentialsJsonString),
            });

            return FirebaseMessaging.GetMessaging(firebaseApp); 
        }

        public async Task<bool> SendFcm(FcmModel message)
        {
            var fireBaseMessage = new Message()
            {
                Notification = new Notification { Body = message.Body, Title = message.Title },
                Data = message.Message,
                Token = message.Token
            };

            try
            {
                var res = await FirebaseMessagingInstance.SendAsync(fireBaseMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
