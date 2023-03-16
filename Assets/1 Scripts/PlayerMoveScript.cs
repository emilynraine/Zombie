using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody _rbody;
    Transform _transform;
    float _scale = 8;
    bool _movement = true;
    MSMScript _manager;
    public AudioClip _deathSound;
    AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody>();
        _transform = transform;
        _manager = FindObjectOfType<MSMScript>();

        //Initialize Audio
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player left and right based on arrow keys
        if(_movement)
        {
            Vector3 move = new Vector3(_scale * Input.GetAxis("Horizontal"), 0, _scale * Input.GetAxis("Vertical"));
            _transform.position +=  _transform.rotation * (Time.deltaTime * move);

            if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                _rbody.velocity = Vector3.zero;
            }
        }

        if(_transform.localPosition.y >= 20)
        {
            _transform.localPosition = new Vector3(_transform.localPosition.x, 19.9f, _transform.localPosition.z);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Shark" || c.gameObject.tag == "Fish")
        {
            _manager._playerIsAlive = false;
            PlayDeath();
            print("Died");
        }
    }

    public void PlayDeath()
    {
        _audioSource.PlayOneShot(_deathSound);
    }
}
