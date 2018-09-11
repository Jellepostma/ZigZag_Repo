using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;

	// Use this for initialization
	void Start () {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatforms();
        }
        
	}

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
	}
    
    void SpawnPlatforms()
    {
        if((int)Random.Range(0, 6) < 3)
        {
            lastPos += new Vector3(size, 0);
        } else
        {
            lastPos += new Vector3(0, 0, size);
        }
        Instantiate(platform, lastPos, Quaternion.identity);
        if((int)Random.Range(0, 4) < 1) Instantiate(diamond, lastPos + new Vector3(0, 1, 0), diamond.transform.rotation);
    }
}
