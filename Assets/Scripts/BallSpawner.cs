using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;

public class BallSpawner : MonoBehaviour
{
    public BallData _data;
    public GameObject _ballParent;

    private void Update()
    {
        SpawnConditions();
        InitDesiredFrames();
    }

    private void InitDesiredFrames()
    {
        if (_data.spawnAllow)
        {
            _data._spawnTime++;

            if (_data._spawnTime % 60 == 0)
            {
                var _spawnedBall = Instantiate(_data._ball, _data._ballSpawnPosition.position, Quaternion.identity);

                _spawnedBall.GetComponent<Rigidbody>().AddForce(Vector3.down * 5f, ForceMode.Impulse);

                _spawnedBall.transform.SetParent(_ballParent.transform);
                                                                            //TEMPLATE HELPER
                _spawnedBall.GetComponent<MeshRenderer>().material.color = ColorExtensions.random;

                if (_spawnedBall)
                {
                    Destroy(_spawnedBall, 5);
                }
            }
        }
    }

    private void SpawnConditions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _data.spawnAllow = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _data.spawnAllow = true;
        }
    }
}
