using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStates : MonoBehaviour
{
    public static GameStates Instance;
    public States _state;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(States _desiredState)
    {
        _state = _desiredState;
    }
}

public enum States
{
    Play,
    Finish
}
