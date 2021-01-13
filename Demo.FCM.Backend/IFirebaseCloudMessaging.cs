using System.Threading.Tasks;

namespace Demo.FCM.Backend
{
    public interface IFirebaseCloudMessaging
    {
        Task<bool> SendFcm(FcmModel message);
    }
}
