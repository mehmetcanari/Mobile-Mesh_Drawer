using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Collider _radiusCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IInteractable _brickInteract))
        {
            StartCoroutine(ExplosionTask(_radiusCollider));

            _brickInteract.PhysicTask();

            //_brickInteract.MeshTask();

            //SelfDestroy();
        }
    }


    protected IEnumerator ExplosionTask(Collider _radius)
    {
        _radius.enabled = true;
        yield return null;
        Destroy(gameObject);
    }
}
