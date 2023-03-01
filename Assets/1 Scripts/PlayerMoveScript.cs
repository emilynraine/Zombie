using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    CharacterController _charCon;
    Transform _transform;
    float _ySpeed = 0;
    float _scale = 8;

    // Start is called before the first frame update
    void Start()
    {
        _charCon = GetComponent<CharacterController>();
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Generalized so that the rotation is not dependent on a calculated amount
        _charCon.Move(_transform.rotation * (Time.deltaTime * new Vector3(_scale * Input.GetAxis("Horizontal"), _ySpeed, _scale * Input.GetAxis("Vertical"))));
    }
}
