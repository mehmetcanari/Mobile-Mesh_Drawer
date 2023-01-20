using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProduceMoney : MonoBehaviour
{
    public CoinData _coinData;
    private UnityEvent TaskCalling;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            Coin();
            ChoosedPosition();

            SpawnCoin(_coinData);
        }
    }

    private GameObject Coin()
    {
        var _coins = _coinData._coins;

        var _choosedCoin = _coins[Random.Range(0, _coins.Count)];

        return _choosedCoin;
    }

    private Transform ChoosedPosition()
    {
        var _positions = _coinData._coinSpawnPositions;

        var _choosedPosition = _positions[Random.Range(0, _positions.Count)];

        return _choosedPosition;
    }

    private void SpawnCoin(CoinData _coin)
    {
        var spawnedCoin = Instantiate(Coin(), ChoosedPosition().position, Quaternion.identity);

        spawnedCoin.GetComponent<Rigidbody>().AddForce(Vector3.down * 50 * Time.deltaTime, ForceMode.Impulse);

        Destroy(spawnedCoin, 1f);
    }
}
