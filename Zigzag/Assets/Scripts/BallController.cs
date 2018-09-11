using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    [SerializeField]
    private float speed;
    bool started = false;
    bool gameOver = false;
    Rigidbody rb;

    public GameObject particles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.instance.StartGame();
            }
        } else
        {
            if (Input.GetMouseButtonDown(0) && !gameOver)
            {
                SwitchDirection();
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            Camera.main.gameObject.GetComponent<CameraFollow>().gameOver = true;
            GameManager.instance.GameOver();
            rb.velocity = new Vector3(0, -25f, 0);
        }
	}

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        } else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Diamond")
        {
            GameObject temp_P = Instantiate(particles, other.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(temp_P, 1f);
        }
    }
}
