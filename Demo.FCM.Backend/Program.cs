using System;
using System.Collections.Generic;

namespace Demo.FCM.Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            IFirebaseCloudMessaging firebaseCloudMessaging = new FirebaseCloudMessaging();

            var message = new FcmModel
            {
                Title = "Hey, there!",
                Body = "Vithu here",
                Message = new Dictionary<string, string>() { {"Key","value"} },
                Token = "Your device token goes here"
            };

            firebaseCloudMessaging.SendFcm(message);
        }
    }
}
