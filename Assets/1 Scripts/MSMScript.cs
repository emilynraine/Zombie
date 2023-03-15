using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSMScript : MonoBehaviour
{
    AudioSource _mainAudioSource;
    public GameObject _fish1;
    public GameObject _shark;
    public List<GameObject> _waypoints;
    float _timeSinceShark = 5;
    // Start is called before the first frame update
    void Start()
    {
        _mainAudioSource = GetComponent<AudioSource>();
        _mainAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceShark = _timeSinceShark + Time.deltaTime;
        if(_timeSinceShark > 10)
        {
            _timeSinceShark = 0;
            int location = Random.Range(0, 9);
            GameObject shark = GameObject.Instantiate(_shark);
            shark.transform.position = _waypoints[location].transform.position;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        int rand = Random.Range(1, 750);
        if(rand == 250)
        {
            GameObject fish = GameObject.Instantiate(_fish1);
            fish.transform.position = new Vector3(10, 2, -66);
        }
    }
}
