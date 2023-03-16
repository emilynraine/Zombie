using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MSMScript : MonoBehaviour
{
    AudioSource _mainAudioSource;
    public GameObject _fish1;
    public GameObject _shark;
    public List<GameObject> _waypoints;
    float _timeSinceShark = 5;
    public bool _playerIsAlive = true;
    public int _score = 0;
    public int _difficulty = 10;
    public Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _mainAudioSource = GetComponent<AudioSource>();
        _mainAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(_score > 3 && _difficulty > 5)
        {
            _difficulty = 5;
        }
        if(_score > 5 && _difficulty > 3)
        {
            _difficulty = 3;
        }

        _scoreText.text = "" + _score.ToString();
        if (_playerIsAlive)
        {
            _timeSinceShark = _timeSinceShark + Time.deltaTime;
            if (_timeSinceShark > _difficulty)
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
            if (rand == 250)
            {
                GameObject fish = GameObject.Instantiate(_fish1);
                fish.transform.position = new Vector3(10, 2, -66);
            }
        }
        else
        {
            PlayerPrefs.SetInt("currScore", _score);

            if (PlayerPrefs.HasKey("highScore"))
            {
                if (_score > PlayerPrefs.GetInt("highScore"))
                {
                    PlayerPrefs.SetInt("highScore", _score);
                }
            }
            else
            {
                PlayerPrefs.SetInt("highScore", _score);
            }
            PlayerPrefs.Save();
            Invoke("LoadRestartScene", 3.0f);
        }
    }

    void LoadRestartScene()
    {
        SceneManager.LoadScene("RestartScene");

    }

    public void IncreaseScore()
    {
        _score++;
    }
}
