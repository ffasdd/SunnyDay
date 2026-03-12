using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
     [SerializeField]  Sprite buildingsSprite_one;
     [SerializeField]  Sprite buildingsSprite_two;
     [SerializeField]  Sprite buildingsSprite_three;
     [SerializeField]  Sprite buildingsSprite_four;
    public Vector2 StartPosition = Vector2.zero;
    public int MaxBulidingCount = 10;
     public float rangeMinX = -10f;
    public float rangeMaxX = 90f;
    public float minDistance = 11f;
    List<float> buildingXList = new List<float>();

      void Start()
    {
        for (int i = 0; i < MaxBulidingCount; i++)
        {
            float newX;
            if (!TryGetNonOverlappingX(out newX))
            {
                Debug.Log("더 이상 안 겹치게 넣을 자리 없음. 생성 중단" + i);
                break;
            }

            var building = new GameObject($"Building_{i}");
            building.transform.parent = transform;

            var sr = building.AddComponent<SpriteRenderer>();

            int spriteIndex = Random.Range(0, 4);
            switch (spriteIndex)
            {
                case 0: sr.sprite = buildingsSprite_one; break;
                case 1: sr.sprite = buildingsSprite_two; break;
                case 2: sr.sprite = buildingsSprite_three; break;
                case 3: sr.sprite = buildingsSprite_four; break;
            }

            building.transform.position = new Vector3(newX, 2f, 0f);

            buildingXList.Add(newX);
        }
    }

    bool TryGetNonOverlappingX(out float resultX)
    {
        const int maxTry = 20;
        for (int t = 0; t < maxTry; t++)
        {
            float candidateX = Random.Range(rangeMinX, rangeMaxX);

            bool ok = true;
            foreach (float existingX in buildingXList)
            {
                if (Mathf.Abs(existingX - candidateX) < minDistance)
                {
                    ok = false;
                    break;
                }
            }

            if (ok)
            {
                resultX = candidateX;
                return true;
            }
        }

        resultX = 0f;
        return false;
    }
}