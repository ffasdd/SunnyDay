using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;

    public bool isOn = false;   
    public void OnToggle()
    {
        isOn = !isOn;
        if (isOn)
        {
            On.SetActive(true);
            Off.SetActive(false);
        }
        else
        {
            On.SetActive(false);
            Off.SetActive(true);
        }
    }
}
