using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject gameOverUI;    

    bool isGameOverShown = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); 
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
}
