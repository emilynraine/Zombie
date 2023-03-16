using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFishOnWaypoints : MonoBehaviour
{

    public List<GameObject> _waypoints;
    public GameObject _player;
    Transform _transform;
    Vector3 _destination;
    int _speed = 4;
    int _index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
        int rand = Random.Range(1, 10);
        _index = rand;
        _transform.position = _waypoints[_index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _destination = _waypoints[_index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(_transform.position, _destination, _speed * Time.deltaTime);
        _transform.position = newPos;

        _transform.LookAt(_waypoints[_index].transform);
        Quaternion currentRot = transform.localRotation;
        _transform.localRotation = currentRot;
        _transform.Rotate(new Vector3(0, 90, 0));

        float distance = Vector3.Distance(_transform.position, _destination);
        if(distance <= 0.05)
        {
            if(_index == 9)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }
        }
        
    }
}
