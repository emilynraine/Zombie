using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookScript : MonoBehaviour
{
    Transform _transform;
    public Transform _headTransform;
    float verticalAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalAngle = _transform.eulerAngles.y + (Input.GetAxis("Mouse X") * 4);
        // verticalAngle -= (Input.GetAxis("Mouse Y") * 2);

        // //float temp = _headTransform.eulerAngles.x - (Input.GetAxis("Mouse Y") * 2);
        // verticalAngle = Mathf.Clamp(verticalAngle, -60, 60);

        // _transform.rotation = Quaternion.Euler(0, horizontalAngle, 0);
        // _headTransform.localRotation = Quaternion.Euler(verticalAngle, 0, 0);

        float horizontalAngle = _transform.localEulerAngles.y
            + (Input.GetAxis("Mouse X") * 6);
        verticalAngle = _transform.localEulerAngles.x
            - (Input.GetAxis("Mouse Y") * 6);
        _transform.localEulerAngles = new Vector3(verticalAngle, horizontalAngle, 0);
    }
}
