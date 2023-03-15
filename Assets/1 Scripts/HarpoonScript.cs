using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonScript : MonoBehaviour
{
    Rigidbody _rbody;
    Transform _transform;

    void Start()
    {
        _transform = transform;
        _rbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_rbody.velocity != Vector3.zero)
        {
            _transform.rotation = Quaternion.LookRotation(_rbody.velocity);
        }

    }

    void OnCollisionEnter(Collision c)
    {
        gameObject.SetActive(false);
    }


}
