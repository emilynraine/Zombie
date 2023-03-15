using System.Collections;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerShootScript : MonoBehaviour
{
    MSMScript _manager;
    [SerializeField]
    private AudioClip _shootClip;
    public GameObject _dummyHarpoon;
    public Transform _harpoonSpawnPtX;
    public Transform _harpoonSpawnPtY;
    public GameObject _harpoonPrefab;
    public Text _loadingText;
    public Text _powerUpText;
    public loadingbar _loadingBar;
    public bool _hasUnlimited = false;
    public bool _announced = false;

    Vector3 _harpoonDirection;
    Transform _transform;

    public Image _barImg;
    Color _normalBarColor = new Color(107/255f, 255/255f, 0/255f, 255/255f);
    Color _infinityBarColor = new Color(255 / 255f, 62 / 255f, 228 / 255f, 255 / 255f);
    UnicodeEncoding unicode = new UnicodeEncoding();

    HarpoonPool _harpoonPool;
    bool _isReloaded = true;
    bool _timerStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        _harpoonDirection = _harpoonSpawnPtY.position - _harpoonSpawnPtX.position;
        _dummyHarpoon.SetActive(true);
        _loadingBar.imageComp.fillAmount = 1.0f;
        _loadingText.text = "";
        _manager = FindObjectOfType<MSMScript>();
        
        _harpoonPool = new HarpoonPool(_harpoonPrefab, true, 10);
        _transform = transform;
        _powerUpText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (_hasUnlimited && !_announced)
        {
            StartCoroutine(PowerUpAnnounce());
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_isReloaded)
            {

                StartCoroutine(PlaySound(_shootClip));
                _dummyHarpoon.SetActive(false);

                GameObject harpoon = _harpoonPool.GetObject();
                
                Rigidbody _hRbody = harpoon.GetComponent<Rigidbody>();
                _harpoonDirection = _harpoonSpawnPtY.position - _harpoonSpawnPtX.position;
                _hRbody.velocity = _harpoonDirection * 120;
                harpoon.transform.rotation = Quaternion.LookRotation(_hRbody.velocity);

                harpoon.transform.position = _harpoonSpawnPtX.position;


                harpoon.SetActive(true);

                _isReloaded = false;
                if (!_timerStarted)
                {
                    StartCoroutine(Reload());
                    _loadingBar.imageComp.fillAmount = 0.0f;
                    _loadingText.text = "Reloading...";
                }
                else
                {
                    StartCoroutine(ReloadUnlimited());
                }



            }

        }
        if (Input.GetKey(KeyCode.E))
        {
            if (_hasUnlimited && !_timerStarted)
            {
                StartCoroutine(PowerUpTimer());
            }

        }

    }


    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2.0f);
        _isReloaded = true;
        _loadingText.text = "";
        _dummyHarpoon.SetActive(true);
    }

    IEnumerator ReloadUnlimited()
    {
        yield return new WaitForSeconds(0.1f);
        _isReloaded = true;
        _loadingText.fontSize = 40;
        _loadingText.text = ("\u221e");
        _dummyHarpoon.SetActive(true);

        yield return null;
    }
        IEnumerator PlaySound(AudioClip _clip)
    {
        AudioSource _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _clip;
        _audioSource.Play();
        yield return new WaitForSeconds(_audioSource.clip.length);
    }

    public IEnumerator PowerUpTimer()
    {
        _barImg.color = _infinityBarColor;
        _timerStarted = true;
        yield return new WaitForSeconds(20.0f);
        _timerStarted = false;
        _hasUnlimited = false;
        _barImg.color = _normalBarColor;
        _loadingText.fontSize = 25;
        _loadingText.text = "";
        _announced = false;
    }

    public IEnumerator PowerUpAnnounce()
    {
        _announced = true;
        _powerUpText.text = "Press 'E' to activate instant reloads";
        yield return new WaitForSeconds(5.0f);
        _powerUpText.text = "";
    }

}
