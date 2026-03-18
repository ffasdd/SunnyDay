using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject gameOverUI;  
    [SerializeField] GameObject gameClearUI;

    bool isGameOverShown = false;
    bool isGameClearShown = false;
    // Start is called before the first frame update
    void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); 
        }
        if (gameClearUI != null)
        {
            gameClearUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerDie()
    {
        ShowGameOver();
    }

    public void ShowGameOver()
    {
        if (isGameOverShown) return;

        isGameOverShown = true;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }
    public void OnPlayerClear()
    {
        ShowGameClear();
    }
    public void ShowGameClear()
    {
        if (isGameClearShown) return;

        isGameClearShown = true;
        
        if (gameClearUI != null)
        {
            gameClearUI.SetActive(true);
        }
    }
}
