using Cysharp.Threading.Tasks;

namespace Kogane
{
    public interface IStoreReviewResult
    {
    }
}

namespace Kogane.Internal
{
    internal interface IStoreReview
    {
        UniTask<IStoreReviewResult> RequestReviewAsync();
    }
}