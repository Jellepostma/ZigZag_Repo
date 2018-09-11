using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void StartGame()
    {
        GUIManager.instance.GameStart();
        ScoreManager.instance.StartScore();
        GameObject.Find("Platform_Spawner").GetComponent<PlatformSpawner>().StartSpawning();
    }

    public void GameOver()
    {
        GUIManager.instance.GameOver();
        ScoreManager.instance.StopScore();
        gameOver = true;
    }
}
