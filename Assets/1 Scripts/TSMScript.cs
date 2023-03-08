using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TSMScript : MonoBehaviour
{
    //AudioSource _titleAudioSource;
    public Text _highScoreText;
    public int _highScore;


    // Start is called before the first frame update
    void Start()
    {
        /* _titleAudioSource = GetComponent<AudioSource>();

         if (PlayerPrefs.HasKey("currHighScore"))    //NEED to check if key exists
         {
             _highScore = PlayerPrefs.GetInt("currHighScore");
             print("Previous high score is:" + PlayerPrefs.GetInt("currHighScore"));
         }
         else
         {
             _highScore = 0;
         }*/
        _highScore = 0;
        _highScoreText.text = "High Score: " + _highScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
