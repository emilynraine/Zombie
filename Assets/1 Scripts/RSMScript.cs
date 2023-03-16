using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//asteroids
public class RSMScript : MonoBehaviour
{
   public Text _scoreText;
   public Text _highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _scoreText.text = "Your Score: " + PlayerPrefs.GetInt("currScore");
        _highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        
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
