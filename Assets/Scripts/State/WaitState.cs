using UnityEngine;
using Cysharp.Threading.Tasks;

public class WaitState : PlayerStateBase
{
    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("WaitState Initialize");
    }

    public override async UniTask EnterAsync()
    {
        await base.EnterAsync();
        Debug.Log("WaitState Enter");
        await UniTask.CompletedTask;
    }

    public override async UniTask ExitAsync()
    {
        await base.ExitAsync();
        Debug.Log("WaitState Exit");
        await UniTask.CompletedTask;
    }
}
