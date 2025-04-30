using UnityEngine;
using System.Collections.Generic;
using System;
using UniRx;
using Cysharp.Threading.Tasks;

public class PlayerStateManager
{
    private static PlayerStateManager _instance;

    public static PlayerStateManager Instance
    {
        get
        {
            _instance ??= new PlayerStateManager();
            return _instance;
        }
    }

    private ReactiveProperty<PlayerState> _playerState;
    private Dictionary<PlayerState, PlayerStateBase> _stateBaseDictionary;
    
    public PlayerState PlayerState { get { return _playerState.Value; } }

    public void Initialize()
    {
        Debug.Log("PlayerStateManager initialize");
        
        _stateBaseDictionary = new Dictionary<PlayerState, PlayerStateBase>();
        
        RegisterState(PlayerState.Boot, new BootState());
        RegisterState(PlayerState.Wait, new WaitState());
        RegisterState(PlayerState.Walk, new WalkState());
        
        _playerState = new ReactiveProperty<PlayerState>(PlayerState.Boot);

        _playerState.Pairwise().Subscribe(async states => await OnChangeState(states.Previous, states.Current));
    }

    public void Dispose()
    {
        Debug.Log("PlayerStateManager dispose");

        foreach (PlayerStateBase stateBase in _stateBaseDictionary.Values)
        {
            (stateBase as IDisposable)?.Dispose();
        }
        _playerState?.Dispose();
    }

    public void RegisterState(PlayerState state, PlayerStateBase stateBase)
    {
        if (!_stateBaseDictionary.ContainsKey(state))
        {
            _stateBaseDictionary[state] = stateBase;
        }
        _stateBaseDictionary[state].Initialize();
    }

    public void UpdateState(PlayerState state)
    {
        Debug.Log($"PlayerStateManager UpdateState: {state}");

        _playerState.Value = state;
    }

    private async UniTask OnChangeState(PlayerState currentState, PlayerState newState)
    {
        Debug.Log($"PlayerStateManager OnChangeState: {currentState} -> {newState}");
        await _stateBaseDictionary[currentState].ExitAsync();
        await _stateBaseDictionary[newState].EnterAsync();
    }
}
