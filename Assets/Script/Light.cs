using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private int rayCount = 36; // 레이 개수
    [SerializeField] private float rayDistance = 1000f;
    [SerializeField] private float startAngle = 0f; // 시작 각도 (도 단위)
    [SerializeField] private float endAngle = 180f; // 끝 각도 (도 단위) - 반원 기본값
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
{
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
                Debug.Log("Player hit");
            }
        }
    }
}

}
