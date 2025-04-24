using UnityEngine;
using Cysharp.Threading.Tasks;

public class WalkState : PlayerStateBase
{
    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("WalkState Initialize");
    }

    public override async UniTask EnterAsync()
    {
        await base.EnterAsync();
        Debug.Log("WalkState Enter");
        await UniTask.CompletedTask;
    }

    public override async UniTask ExitAsync()
    {
        await base.ExitAsync();
        Debug.Log("WalkState Exit");
        await UniTask.CompletedTask;
    }
}
