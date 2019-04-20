using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAmmo : MonoBehaviour
{
    public Text text;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        this.text.text = "";
    }
}
