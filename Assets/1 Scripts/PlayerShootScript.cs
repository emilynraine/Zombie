using System.Collections;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShootScript : MonoBehaviour
{
    MSMScript _manager;
    //[SerializeField]
    //private AudioClip _shootClip;
    //[SerializeField]
    //private AudioClip _damageClip;
    public GameObject _dummyHarpoon;
    public Transform _harpoonSpawnPt;
    public GameObject _harpoonPrefab;
    public Text _loadingText;
    public loadingbar _loadingBar;

    Transform _transform;

    HarpoonPool _harpoonPool;
    bool _isReloaded = true;

    // Start is called before the first frame update
    void Start()
    {
        _dummyHarpoon.SetActive(true);
        _loadingBar.imageComp.fillAmount = 1.0f;
        _loadingText.text = "";
        _manager = FindObjectOfType<MSMScript>();
        
        _harpoonPool = new HarpoonPool(_harpoonPrefab, true, 10);
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isReloaded)
            {

                //StartCoroutine(PlaySound(_shootClip));

                GameObject harpoon = _harpoonPool.GetObject();

                harpoon.transform.position = _harpoonSpawnPt.position;
                harpoon.transform.rotation = _transform.rotation;

                _dummyHarpoon.SetActive(false);
                harpoon.SetActive(true);
                

                _isReloaded = false;
                StartCoroutine(Reload());
                _loadingBar.imageComp.fillAmount = 0.0f;
                _loadingText.text = "Reloading...";


            }

        }


            //}
       // }
    }


    void OnCollisionEnter(Collision c)
    {
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2.0f);
        _isReloaded = true;
        _loadingText.text = "";
        _dummyHarpoon.SetActive(true);
    }
    /*IEnumerator PlaySound(AudioClip _clip)
    {
        AudioSource _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _clip;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
    }

    IEnumerator PlaySoundInactive(AudioClip _clip)
    {
        AudioSource _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _clip;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);


    }*/
}
