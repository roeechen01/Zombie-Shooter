using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
            Zombie.aliveZombies.Clear();
        }
            
	}

    public static void MakeSmaller(GameObject gameObject)
    {
        gameObject.transform.localScale *= 0.9f;
    }
}
