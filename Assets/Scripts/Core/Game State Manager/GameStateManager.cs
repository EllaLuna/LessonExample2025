using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    List<GameState> states = new();
    [SerializeField] GameState currentState;
    [SerializeField] GameState defaultState;
    
    void Awake()
    {
        states.AddRange(GetComponentsInChildren<GameState>());

        Events.OnStateEnter += StateEnter;
        Events.OnStateExit += StateExit;
        Events.OnGetCurrentState += GetCurrentState;
    }

    private GameState GetCurrentState()
    {
        return currentState;
    }

    private void StateExit(GameState obj)
    {
        throw new NotImplementedException();
    }

    private void StateEnter(GameState obj)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
