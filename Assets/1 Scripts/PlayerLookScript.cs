using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLookScript : MonoBehaviour
{
    Transform _transform;
    float verticalAngle = 0;
    MSMScript _manager;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        _manager = FindObjectOfType<MSMScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_manager._playerIsAlive)
        {
            float horizontalAngle = _transform.eulerAngles.y + (Input.GetAxis("Mouse X") * 4);
            verticalAngle -= (Input.GetAxis("Mouse Y") * 4);
            verticalAngle = Mathf.Clamp(verticalAngle, -60, 60);

            _transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
        }
    }
}
