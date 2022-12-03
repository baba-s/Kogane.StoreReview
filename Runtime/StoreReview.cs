using System.Threading;
using Cysharp.Threading.Tasks;
using Kogane.Internal;
using UnityEngine;

namespace Kogane
{
    public interface IStoreReviewResult
    {
    }

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

        public static async UniTask<IStoreReviewResult> RequestReviewAsync<T>( T component ) where T : Component
        {
            return await RequestReviewAsync( component.gameObject );
        }

        public static async UniTask<IStoreReviewResult> RequestReviewAsync( GameObject gameObject )
        {
            return await RequestReviewAsync( gameObject.GetCancellationTokenOnDestroy() );
        }

        public static async UniTask<IStoreReviewResult> RequestReviewAsync( CancellationToken cancellationToken )
        {
            return await m_instance.RequestReviewAsync( cancellationToken );
        }
    }
}