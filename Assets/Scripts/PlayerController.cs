using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        PlayerStateManager.Instance.Initialize();
        
        PlayerStateManager.Instance.UpdateState(PlayerState.Wait);
        
        gameObject.OnDestroyAsObservable().Subscribe(_ => Dispose()).AddTo(this);
    }

    private void Dispose()
    {
        PlayerStateManager.Instance.Dispose();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerStateManager.Instance.UpdateState(PlayerState.Walk);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerStateManager.Instance.UpdateState(PlayerState.Boot);
        }
    }
}
