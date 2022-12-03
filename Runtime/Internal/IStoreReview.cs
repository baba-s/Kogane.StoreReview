using System.Threading;
using Cysharp.Threading.Tasks;

namespace Kogane.Internal
{
    internal interface IStoreReview
    {
        UniTask<IStoreReviewResult> RequestReviewAsync( CancellationToken cancellationToken );
    }
}