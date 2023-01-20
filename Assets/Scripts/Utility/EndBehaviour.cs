using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Events;

public class EndBehaviour : MonoBehaviour
{
    public List<GameObject> _bricks;
    public BrokenCounter _dataStore;
    public int _brickCount;
    public int _winPercentage;

    public UnityEvent _endTask;

    private void Start()
    {
        GetCount();
    }

    private void Update()
    {
        switch (GameStates.Instance._state)
        {
            case States.Play:
                CheckPercentage();
                break;
        }
    }

    private void GetCount()
    {
        _brickCount = _bricks.Count;
    }

    private int CalculatePercentage()
    {
        int _percentage = (int)Mathf.Round((_dataStore.Counter * 100) / _brickCount);

        return _percentage;
    }

    private void CheckPercentage()
    {
        if (CalculatePercentage() >= _winPercentage)
        {
            GameStates.Instance.ChangeState(States.Finish);

            _endTask?.Invoke();
        }
    }
}
