using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonTipScript : MonoBehaviour
{
    public Rigidbody _rbody;
    Transform _transform;
    HarpoonScript _parent;
    Transform _parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _rbody = GetComponent<Rigidbody>();
        //StartCoroutine(WaitAndInactive());
    }

    // Update is called once per frame
    void Update()
    {
        if (_parentTransform != null && _parent != null)
        {
            _rbody.velocity = _parentTransform.rotation * new Vector3(0, 0, -20);
           

        }

       }

    public void SetParentTransform(Transform _pTransform)
    {
        _parentTransform = _pTransform;

    }

    public void SetParent(HarpoonScript p)
    {
        _parent = p;
    }


   IEnumerator WaitAndInactive()
    {
        yield return new WaitForSeconds(5.0f);
        _parent.SetInactive();
    }
}
