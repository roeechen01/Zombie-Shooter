using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speed = 0.1f;
    private Camera gameCamera;


    // Use this for initialization
    void Start () {
        SetUpGame.MakeSmaller(gameObject);
        gameCamera = FindObjectOfType<Camera>();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, 0f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + speed, 0f);
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
        Movement();
        Rotaion();
        CameraController();
    }

    void CameraController()
    {
        gameCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, gameCamera.transform.position.z);
    }
}
