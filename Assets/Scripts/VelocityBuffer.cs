using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityBuffer : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _velocityMultiplier;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Path"))
        {
            _rigidbody.velocity *= _velocityMultiplier * Time.deltaTime;
        }
    }
}
