#if UNITY_EDITOR || UNITY_ANDROID

using System;
using System.Diagnostics.CodeAnalysis;
using Cysharp.Threading.Tasks;
using Google.Play.Review;
using JetBrains.Annotations;
using UnityEngine;

namespace Kogane.Internal
{
    [Serializable]
    [SuppressMessage( "ReSharper", "NotAccessedField.Local" )]
    internal struct AndroidStoreReviewResult : IStoreReviewResult
    {
        [SerializeField] private bool   m_isDone;
        [SerializeField] private bool   m_isSuccessful;
        [SerializeField] private string m_error;

        public AndroidStoreReviewResult
        (
            bool   isDone,
            bool   isSuccessful,
            string error
        )
        {
            m_isDone       = isDone;
            m_isSuccessful = isSuccessful;
            m_error        = error;
        }
    }

    [UsedImplicitly]
    internal sealed class AndroidStoreReview : IStoreReview
    {
        async UniTask<IStoreReviewResult> IStoreReview.RequestReviewAsync()
        {
            // https://developer.android.com/guide/playcore/in-app-review/unity?hl=ja
            var reviewManager        = new ReviewManager();
            var requestFlowOperation = reviewManager.RequestReviewFlow();

            await requestFlowOperation;

            if ( requestFlowOperation.Error != ReviewErrorCode.NoError )
            {
                return new AndroidStoreReviewResult
                (
                    isDone: requestFlowOperation.IsDone,
                    isSuccessful: requestFlowOperation.IsSuccessful,
                    error: requestFlowOperation.Error.ToString()
                );
            }

            var playReviewInfo = requestFlowOperation.GetResult();

            var launchFlowOperation = reviewManager.LaunchReviewFlow( playReviewInfo );
            await launchFlowOperation;

            if ( launchFlowOperation.Error != ReviewErrorCode.NoError )
            {
                return new AndroidStoreReviewResult
                (
                    isDone: launchFlowOperation.IsDone,
                    isSuccessful: launchFlowOperation.IsSuccessful,
                    error: launchFlowOperation.Error.ToString()
                );
            }

            return new AndroidStoreReviewResult
            (
                isDone: true,
                isSuccessful: true,
                error: string.Empty
            );
        }
    }
}

#endif