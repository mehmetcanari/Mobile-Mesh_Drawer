using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    public SceneData _levelData;
    public UnityEvent _callLevel;

    private void Awake()
    {
        _callLevel?.Invoke();
    }

    public void InitiliazeLevel()
    {
        var _level = Instantiate(_levelData._level, Vector3.zero, Quaternion.identity);
    }
}
