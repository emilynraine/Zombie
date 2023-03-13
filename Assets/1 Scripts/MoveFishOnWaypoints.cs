using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFishOnWaypoints : MonoBehaviour
{

    public List<GameObject> _waypoints;
    public GameObject _player;
    Transform _transform;
    Vector3 _destination;
    int _speed = 5;
    int _index = 0;
    bool _isDeadly;

    // Start is called before the first frame update
    void Start()
    {
        //Set the type of fish
        int rand = Random.Range(0,2);
        if(rand == 1)
        {
            _isDeadly = true;
        }
        else
        {
            _isDeadly = false;
        }

        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isDeadly)
        {
            _destination = _waypoints[_index].transform.position;
            Vector3 newPos = Vector3.MoveTowards(_transform.position, _destination, _speed * Time.deltaTime);
            _transform.position = newPos;

            if(newPos != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(newPos, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 15 * Time.deltaTime);
            }

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
        else
        {
            Vector3 destination = _player.transform.position;
            Vector3 newPos = Vector3.MoveTowards(_transform.position, destination, _speed * Time.deltaTime);
            _transform.position = newPos;
        }
        
    }
}
