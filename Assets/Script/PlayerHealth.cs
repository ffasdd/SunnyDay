using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth = 100f;
    public float currenthealth;

    [SerializeField] UIManagerScript uiManager;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    public void TakeDamage(float damage){
        currenthealth -= damage;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);

        // Debug.Log("현재 체력: " + currenthealth);

        if(currenthealth <= 0){
            Die();
        }
    }

    public void Die(){
        uiManager.OnPlayerDie();
        Debug.Log("Player is dead");

    }

}
