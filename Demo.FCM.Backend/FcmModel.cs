using System.Collections.Generic;

namespace Demo.FCM.Backend
{
    public class FcmModel
    {
        public string Token { get; set; }
        public Dictionary<string, string> Message { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
