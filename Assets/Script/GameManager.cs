using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float score;
    public PlayerMove playermove;
    public PlayerHealth playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetScore();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }
    public void Reload(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }
    public void GameResume()
    {
        Time.timeScale = 1;
    }

    public void GetScore(){
        Debug.Log(score);
        //return score;
    }

    public void SetScore()
    {
        float currentDistance = playermove.distance;
        float currentHealth = playerhealth.currenthealth;

        bool isGoal = playermove.isGoal;

        score = currentDistance * currentHealth;
        if(isGoal)
            score += 500;
    }


}
