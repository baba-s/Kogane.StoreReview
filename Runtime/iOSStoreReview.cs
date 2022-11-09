#if UNITY_EDITOR || UNITY_IOS

using System;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.iOS;

namespace Kogane.Internal
{
    [Serializable]
    internal readonly struct iOSStoreReviewResult : IStoreReviewResult
    {
    }

    [UsedImplicitly]
    internal sealed class iOSStoreReview : IStoreReview
    {
        UniTask<IStoreReviewResult> IStoreReview.RequestReviewAsync()
        {
            Device.RequestStoreReview();
            return UniTask.FromResult( ( IStoreReviewResult )new iOSStoreReviewResult() );
        }
    }
}
#endif