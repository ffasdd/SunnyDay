using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float cameraSpeed = 5f;
    [SerializeField] Transform target;
    [SerializeField] float smoothTime = 0.3f;
    
    [Header("Target Offset")]
    [SerializeField] Vector3 targetOffset = new Vector3(0f, 3f, 0f); // 타겟이 화면 아래쪽에 오도록
    
    [Header("Camera Clamp")]
    [SerializeField] bool useClamp = true;
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 188f;
    void Update()
    {
        Vector3 targetPosition = target.transform.position + targetOffset;
        Vector3 dir = targetPosition - this.transform.position;
        Vector3 moveVector = new Vector3(dir.x * cameraSpeed * Time.deltaTime, 0.0f, 0.0f);
        Vector3 newPosition = this.transform.position + moveVector;
        
        // 카메라 위치를 clamp 범위로 제한
        if (useClamp)
        {
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        }
        
        this.transform.position = newPosition;
    }
}
