using UnityEngine;
using Cysharp.Threading.Tasks;

public class WateState : PlayerStateBase
{
    public override void Initialize()
    {
        base.Initialize();
        Debug.Log("WateState Initialize");
    }

    public override async UniTask EnterAsync()
    {
        await base.EnterAsync();
        Debug.Log("WateState Enter");
        await UniTask.CompletedTask;
    }

    public override async UniTask ExitAsync()
    {
        await base.ExitAsync();
        Debug.Log("WateState Exit");
        await UniTask.CompletedTask;
    }
}
