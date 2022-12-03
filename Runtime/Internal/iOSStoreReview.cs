#if UNITY_EDITOR || UNITY_IOS

using System;
using System.Threading;
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
        UniTask<IStoreReviewResult> IStoreReview.RequestReviewAsync( CancellationToken cancellationToken )
        {
            Device.RequestStoreReview();
            return UniTask.FromResult( ( IStoreReviewResult )new iOSStoreReviewResult() );
        }
    }
}
#endif