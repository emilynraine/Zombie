using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//asteroids
public class RSMScript : MonoBehaviour
{
   // public Text _scoreText;
   // public Text _highScoreText;

    int _highScore = 0;
    int _score = 0;

    // Start is called before the first frame update
    void Start()
    {
        /*
        if (PlayerPrefs.HasKey("currScore"))    //NEED to check if key exists
        {
            _score = PlayerPrefs.GetInt("currScore");
        }

        _scoreText.text = "Your Score: " + _score;

        if (PlayerPrefs.HasKey("currHighScore"))    //NEED to check if key exists
        {
            _highScore = PlayerPrefs.GetInt("currHighScore");

        }
        else
        {
            PlayerPrefs.SetInt("currHighScore", 0);
        }

        if (_score > _highScore)
        {
            PlayerPrefs.SetInt("currHighScore", _score);
            print("Set new high score to:" + PlayerPrefs.GetInt("currHighScore"));
        }
        _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("currHighScore");*/

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
