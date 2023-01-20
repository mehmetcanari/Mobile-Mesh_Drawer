using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour, IInteractable
{
    private float _explosionForce = 100;

    public void MeshTask()
    {
        var _collider = gameObject.GetComponent<Collider>();

        _collider.enabled = false;
    }

    public void PhysicTask()
    {
        var _rigidBody = gameObject.GetComponent<Rigidbody>();

        _rigidBody.isKinematic = false;

        _rigidBody.AddForce(Vector3.left * _explosionForce * Time.deltaTime, ForceMode.Impulse);
    }
}
