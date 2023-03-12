using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSharkOnWaypoints : MonoBehaviour
{
    public List<GameObject> _waypoints;
    public GameObject _player;
    float _timeSinceWaypoint = 0;
    Transform _transform;
    bool _chasePlayer = true;
    int _speed = 4;
    int location;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Check the time since last waypoint visit
        _timeSinceWaypoint = _timeSinceWaypoint + Time.deltaTime;
        if(_timeSinceWaypoint > 10)
        {
            _timeSinceWaypoint = 0;
            if(_chasePlayer)
            {
                _chasePlayer = false;
                location = Random.Range(0, 9);
            }
            else
            {
                _chasePlayer = true;
            }
        }

        //Chase the player
        if(_chasePlayer)
        {
            Vector3 destination = _player.transform.position;
            Vector3 newPos = Vector3.MoveTowards(_transform.position, destination, _speed * Time.deltaTime);
            _transform.position = newPos;
        }

        //Follow a waypoint
        if(!_chasePlayer)
        {
            Vector3 destination = _waypoints[location].transform.position;
            Vector3 newPos = Vector3.MoveTowards(_transform.position, destination, _speed * Time.deltaTime);
            _transform.position = newPos;

            if(newPos != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(newPos, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 100 * Time.deltaTime);
            }

            float distance = Vector3.Distance(_transform.position, destination);
            if(distance <= 0.05)
            {
                _timeSinceWaypoint = 10;
            }   
        }

    }
}
