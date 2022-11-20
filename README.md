# Kogane Store Review

iOS / Android でストアのレビュー依頼を表示できるパッケージ

## 使用例

```cs
using Cysharp.Threading.Tasks;
using Kogane;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private async UniTaskVoid Start()
    {
        var result = await StoreReview.RequestReviewAsync();
        Debug.Log( result );
    }
}
```

## 依存しているパッケージ

* https://developers.google.com/unity/archive#play_in-app_review
