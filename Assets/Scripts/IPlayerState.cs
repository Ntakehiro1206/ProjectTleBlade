using Cysharp.Threading.Tasks;

public interface IPlayerState
{
    void Initialize();
    UniTask EnterAsync();
    UniTask ExitAsync();
}

