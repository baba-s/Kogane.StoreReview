using Cysharp.Threading.Tasks;
using Kogane.Internal;

namespace Kogane
{
    public static class StoreReview
    {
        private static readonly IStoreReview m_instance =
#if !UNITY_EDITOR && UNITY_IOS
            new iOSStoreReview();
#elif !UNITY_EDITOR && UNITY_ANDROID
            new AndroidStoreReview();
#else
            new NullStoreReview();
#endif

        public static async UniTask<IStoreReviewResult> RequestReviewAsync()
        {
            return await m_instance.RequestReviewAsync();
        }
    }
}