using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public static Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }
    // Update is called once per frame
    void Update () {
        //based on which button is pressed, change the light's color
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponent<Light>().color = hexToColor("943400FF");
        }
        if (Input.GetMouseButton(1))
        {

            gameObject.GetComponent<Light>().color = hexToColor("4E087AFF");
        }

    }

    
}
