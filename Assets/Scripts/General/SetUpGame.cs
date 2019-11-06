using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetUpGame : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public static bool onPause;
    public Text waveText;
    private string oldWaveText = "";

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        if (onPause)
            TogglePause();
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        slider = FindObjectOfType<Slider>();
        slider.maxValue = 0;
        InventoryWeapon.activeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (onPause)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else TogglePause();

        }
        if (Input.GetKeyDown(KeyCode.Space))
            TogglePause();
    }

    public static void MakeSmaller(GameObject gameObject)
    {
        gameObject.transform.localScale *= 0.9f;
    }

    void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            onPause = false;
            waveText.text = oldWaveText;
            
        }
        else
        {
            Time.timeScale = 0f;
            onPause = true;
            oldWaveText = waveText.text;
            waveText.text = "PAUSE\nRESUME (SPACE)\nRESTART (TAB)\n\n\n\nMENU (ESCAPE)";
        }
    }
}
