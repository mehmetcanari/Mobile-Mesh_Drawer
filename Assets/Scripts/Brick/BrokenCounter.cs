using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenCounter : MonoBehaviour
{
    public int _count;

    private void Awake()
    {
        Counter = 0;
    }

    public int Counter
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
        }
    }
}
