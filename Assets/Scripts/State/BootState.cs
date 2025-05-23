using UnityEngine;
using Cysharp.Threading.Tasks;

public sealed class BootState : PlayerStateBase
{
    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("BootState Initialize");
    }

    public override async UniTask EnterAsync()
    {
        await base.EnterAsync();
        Debug.Log("BootState OnStart");
        await UniTask.CompletedTask;
    }

    public override async UniTask ExitAsync()
    {
        await base.ExitAsync();
        Debug.Log("BootState OnExit");
        await UniTask.CompletedTask;
    }
}
