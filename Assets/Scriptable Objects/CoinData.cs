using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coin Data", menuName = "Converter")]
public class CoinData : ScriptableObject
{
    public List<Transform> _coinSpawnPositions;
    public List<GameObject> _coins;
}
