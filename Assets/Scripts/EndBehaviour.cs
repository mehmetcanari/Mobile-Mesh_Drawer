using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBehaviour : MonoBehaviour
{
    public List<GameObject> _bricks;
    public int _brickCount;

    private void Start()
    {
        GetCount();
    }

    private void GetCount()
    {
        _brickCount = _bricks.Count;
    }
}
