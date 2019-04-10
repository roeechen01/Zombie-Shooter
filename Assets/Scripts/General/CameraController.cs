using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerAttack player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerAttack>();
	}
	
	// Update is called once per frame
	void Update () {
        if(player)
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
	}
}
