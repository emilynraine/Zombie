using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody _rbody;
    Transform _transform;
    float _scale = 8;
    bool _movement = true;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player left and right based on arrow keys
        if(_movement)
        {
            Vector3 move = new Vector3(_scale * Input.GetAxis("Horizontal"), 0, _scale * Input.GetAxis("Vertical"));
            _transform.position +=  _transform.rotation * (Time.deltaTime * move);
        }

        if(_transform.localPosition.y >= 15)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x, 14.5f, _transform.localPosition.z);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Shark")
        {
            print("Died");
        }
    }
}
