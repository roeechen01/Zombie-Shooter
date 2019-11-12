using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float originalSpeed;
    private float speed = 6.5f;
    private Camera gameCamera;
    bool canFreeze = true;
    public bool changeSpeedIfNotStraight = true;


    // Use this for initialization
    void Start () {
        originalSpeed = speed;
        SetUpGame.MakeSmaller(gameObject);
        gameCamera = FindObjectOfType<Camera>();
    }

    void SetSpeedCorrectlyIfNotGoingStraight()
    {
        if ((Input.GetKey(KeyCode.A) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) ||
            (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) ||
            (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))) ||
            (Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))))))
            speed = originalSpeed / Mathf.Sqrt(2);
        else speed = originalSpeed;
    }

    void Movement()
    {
        if(changeSpeedIfNotStraight)
            SetSpeedCorrectlyIfNotGoingStraight();
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = new Vector3(this.transform.position.x - speed * Time.deltaTime, this.transform.position.y, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime, this.transform.position.y, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed * Time.deltaTime, 0f);
        }
    }

   

    void Rotaion()
    {
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos -= object_pos;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
	
	// Update is called once per frame
	void Update () {
        if (!SetUpGame.onPause)
        {

            Movement();
            Rotaion();
            CameraController();
        }
    }

    void CameraController()
    {
        gameCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, gameCamera.transform.position.z);
    }

    public void Freeze (float seconds)
    {
        if (canFreeze)
        {
            canFreeze = false;
            speed = 0;
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.color = new Color(0f, 0.3f, 0.8f);
            Invoke("SetNormalSpeed", seconds);
        }
        
    }

    void SetNormalSpeed()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f);
        speed = originalSpeed;
        Invoke("SetCanFreeze", 1.5f);
    }

    void SetCanFreeze()
    {
        canFreeze = true;
    }
}
