
using UnityEngine;

using System.Collections;
using Leap;

public class Pickup : MonoBehaviour
{
    GameObject _target;

    public void setTarget(GameObject target)
    {
        if (_target == null)
        {
            _target = target;
        }
    }

    public void pickupTarget()
    {
        if (_target)
        {

            StartCoroutine(changeParent());
            Rigidbody rb = _target.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {

                rb.isKinematic = false;
                rb.freezeRotation = true;

            }
        }
    }

    private IEnumerator changeParent()
    {
        yield return null;
        if (_target != null)
        {
            _target.transform.parent = transform;
        }
    }

    public void releaseTarget()
    {
        if (_target && _target.activeInHierarchy)
        {
            if (_target.transform.parent == transform)
            {
                Rigidbody rb = _target.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;

                }
                _target.transform.parent = null;
            }
            _target = null;
        }
    }

    public void clearTarget()
    {
        _target = null;
    }
}
