using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class General : MonoBehaviour {

    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        if (FindObjectsOfType<General>().Length > 1)
            Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);            
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
            else audioSource.UnPause();
        }
	}
}
