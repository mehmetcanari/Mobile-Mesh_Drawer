using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public SphereCollider _radiusCollider;

    [Header("Explosion Affect Area")]
    [Range(1,4)]
    public float _radius;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.gameObject.layer == 8)
        {
            SelfDestroy();
        }
        else
        {
            if (collision.transform.TryGetComponent(out IInteractable _brickInteract))
            {
                StartCoroutine(ExplosionTask(_radiusCollider));

                _brickInteract.PhysicTask();
            }
        }
    }


    protected IEnumerator ExplosionTask(SphereCollider _collider)
    {
        _collider.radius = _radius;
        _collider.enabled = true;
        yield return null;
        Destroy(gameObject);
    }

    protected void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
