using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering;

public sealed class BootState : PlayerStateBase
{
    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("BootState Initialize");
    }

    public override async UniTask OnEnterAsync()
    {
        await base.OnEnterAsync();
        Debug.Log("BootState OnStart");
        await UniTask.CompletedTask;
    }

    public override async UniTask OnExitAsync()
    {
        await base.OnExitAsync();
        Debug.Log("BootState OnExit");
        await UniTask.CompletedTask;
    }
}
