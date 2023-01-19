using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Ball Identity")]
public class BallData : ScriptableObject
{
    public GameObject _ball;
    public Transform _ballSpawnPosition;
    [HideInInspector] public float _spawnTime;
    public bool spawnAllow;
}
