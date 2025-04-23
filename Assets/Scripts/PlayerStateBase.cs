using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerStateBase: IPlayerState, IDisposable
{
    //初期化メソッド
    public virtual void Initialize()
    {
        Debug.Log("PlayerStateBase Initialize");
    }
    
    //破棄メソッド
    public void Dispose()
    {
        Debug.Log($"{this.GetType().Name} is Dispose");
    }

    //状態が始まったときの処理
    public virtual async UniTask EnterAsync()
    {
        Debug.Log("PlayerStateBase EnterAsync");
        await UniTask.CompletedTask;
    }

    //状態が終わるときの処理
    public virtual async UniTask ExitAsync()
    {
        Debug.Log("PlayerStateBase ExitAsync");
        await UniTask.CompletedTask;
    }
}
