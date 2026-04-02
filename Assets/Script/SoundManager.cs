using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioClip inGameBGM;
    [SerializeField] private AudioSource JumpSoundSource;
    [SerializeField] private AudioClip JumpSound;
    private void Awake()
    {
        Instance = this;
    }    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.Play();
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void BGMSet(bool isOn)
    {
        if (isOn)
        {
            PlayBGM(inGameBGM);
        }
        else
        {
            StopBGM();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGame")
        {
            PlayBGM(inGameBGM);
        }
    }
    public void JumpSoundPlay()
    {
        JumpSoundSource.PlayOneShot(JumpSound);
    }
}
