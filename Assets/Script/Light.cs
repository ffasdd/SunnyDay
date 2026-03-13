using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private int rayCount = 30; // 레이 개수
    [SerializeField] private float rayDistance = 500f;
    [SerializeField] private float startAngle = 179f; // 시작 각도 (도 단위)
    [SerializeField] private float endAngle = 181f; // 끝 각도 (도 단위) - 반원 기본값
    
    [SerializeField] private float damagePerSecond = 1f;

    private float damageTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damageTimer += Time.deltaTime;

        bool isPlayerHit = false;

        float angleRange = endAngle - startAngle;
        float angleStep = angleRange / (rayCount - 1);

        for (int i = 0; i < rayCount; i++)
        {
            float angle = (startAngle + i * angleStep) * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));

            Debug.DrawRay(transform.position, direction * rayDistance, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, rayDistance);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    // Debug.Log("Player hit");
                    isPlayerHit = true;
                    break;
                }
            }

            
       
    }

    // 플레이어가 hit 상태이고 1초 이상이 지났다면
            if (isPlayerHit && damageTimer >= 1f)
            {
                PlayerHealth playerHealth = FindFirstObjectByType<PlayerHealth>();
                playerHealth.TakeDamage(damagePerSecond);
                damageTimer = 0f;
                
            }
}

}
