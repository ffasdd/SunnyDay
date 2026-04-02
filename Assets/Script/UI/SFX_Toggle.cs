using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX_Toggle : MonoBehaviour
{
    public GameObject On;
    public GameObject Off;
    [SerializeField] private SoundManager soundManager;
    public bool isOn = false;   
    public void OnToggle()
    {
        isOn = !isOn;
        if (isOn)
        {
            soundManager.SFXSet(true);
            On.SetActive(true);
            Off.SetActive(false);
        }
        else
        {
            soundManager.SFXSet(false);
            On.SetActive(false);
            Off.SetActive(true);
        }
    }
}
