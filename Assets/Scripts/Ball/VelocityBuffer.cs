using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voxelity.Extensions;

public class VelocityBuffer : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float _velocityMultiplier;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Path"))
        {
            if(_rigidbody.velocity.magnitude > 10)
            {
                _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity,
                    10);
            }
            else
            {
                _rigidbody.velocity *= _velocityMultiplier * Time.deltaTime;
            }
        }
    }
}
