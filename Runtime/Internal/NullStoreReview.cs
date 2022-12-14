#if UNITY_EDITOR || (!UNITY_IOS && !UNITY_ANDROID)

using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;

namespace Kogane.Internal
{
    [Serializable]
    internal readonly struct NullStoreReviewResult : IStoreReviewResult
    {
    }

    [UsedImplicitly]
    internal sealed class NullStoreReview : IStoreReview
    {
        UniTask<IStoreReviewResult> IStoreReview.RequestReviewAsync( CancellationToken cancellationToken )
        {
            return UniTask.FromResult( ( IStoreReviewResult )new NullStoreReviewResult() );
        }
    }
}

#endif