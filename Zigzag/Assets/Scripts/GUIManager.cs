using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

    public static GUIManager instance;

    public GameObject zigZagPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public Text score;
    public Text zigzagHighscore;
    public Text gameoverHighscore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        zigzagHighscore.text = (PlayerPrefs.HasKey("highscore")) ? "Highscore: " + PlayerPrefs.GetInt("highscore").ToString() : "Highscore: 0";
    }

    public void GameStart()
    {
        
        tapText.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("Panel_Up");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        gameoverHighscore.text = PlayerPrefs.GetInt("highscore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
