using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxhealth = 100f;
    public float currenthealth;
    public float maxHPBarWidth;
    [SerializeField] UIManagerScript uiManager;
    [SerializeField] RectTransform HPBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;

        if (HPBar != null)
        {
            maxHPBarWidth = HPBar.sizeDelta.x;
        }
    }

    public void TakeDamage(float damage){
        currenthealth -= damage;
        currenthealth = Mathf.Clamp(currenthealth, 0, maxhealth);

        UpdateHPBar();

        // Debug.Log("현재 체력: " + currenthealth);

        if(currenthealth <= 0){
            Die();
        }
    }

    void UpdateHPBar(){
        if(HPBar == null ) return;

        float ratio = currenthealth / maxhealth;

        Vector2 size = HPBar.sizeDelta;
        size.x = maxHPBarWidth * ratio;
        HPBar.sizeDelta = size;
    }

    public void Die(){
        uiManager.OnPlayerDie();
        Debug.Log("Player is dead");

    }

}
