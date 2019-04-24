using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour {

    public bool localPlayer;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    void EnableCamera()
    {
        Camera camera = GetComponentInChildren<Camera>();
        camera.enabled = true;
        camera.gameObject.GetComponent<AudioListener>().enabled = true;
    }
    // Update is called once per frame
    void Update () {
		
	}

    public override void OnStartLocalPlayer()
    {
        localPlayer = true;
        EnableCamera();
    }
}
