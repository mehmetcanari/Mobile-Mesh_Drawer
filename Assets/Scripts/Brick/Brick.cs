using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, IInteractable
{
    private float _explosionForce = 100;
    private bool _canExecute = true;
    public BrokenCounter _data;

    public void PhysicTask()
    {
        if (_canExecute)
        {
            var _rigidBody = gameObject.GetComponent<Rigidbody>();

            _rigidBody.isKinematic = false;

            _rigidBody.AddForce(Vector3.left * _explosionForce * Time.deltaTime, ForceMode.Impulse);

            _canExecute = false;

            _data.Counter++;
        }
    }
}
