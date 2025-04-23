using Cysharp.Threading.Tasks;

public interface IPlayerState
{
    void Initialize();
    UniTask OnEnterAsync();
    UniTask OnExitAsync();
}

