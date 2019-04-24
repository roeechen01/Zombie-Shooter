using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour {

    Text text;
    PlayerAttack player;

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        foreach(PlayerAttack player in FindObjectsOfType<PlayerAttack>())
        {
            if (player.GetComponent<PlayerNetwork>().localPlayer)
            {
                this.player = player;
                break;
            }
        }
        player = FindObjectOfType<PlayerAttack>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetLifeToText() > 0)
            text.text = "LIFE: " + player.GetLifeToText();
        else text.text = "DEAD";
	}
}
