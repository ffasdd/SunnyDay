using System.Collections.Generic;
using UnityEngine;
[System.Serializable]public class BuildingData{
        public GameObject BuildingPrefab;
        public float spawnY;
    }
public class Map : MonoBehaviour
{
    [SerializeField] private BuildingData[] buildings;

    public Vector2 StartPosition = Vector2.zero;
    public int MaxBulidingCount = 20;
    public float rangeMinX = 0f;
    public float rangeMaxX = 170f;
    public float minDistance = 8f;

    private List<float> buildingXList = new List<float>();

    void Start()
    {
        if (buildings == null || buildings.Length == 0)
        {
            Debug.LogError("buildings가 비어있습니다.");
            return;
        }

        for (int i = 0; i < MaxBulidingCount; i++)
        {
            float newX;
            if (!TryGetNonOverlappingX(out newX))
            {
                Debug.Log("더 이상 안 겹치게 넣을 자리 없음. 생성 중단: " + i);
                break;
            }

            int prefabIndex = Random.Range(0, buildings.Length);
            BuildingData selected = buildings[prefabIndex];

            if (selected.BuildingPrefab == null)
            {
                Debug.LogWarning($"buildings[{prefabIndex}]가 비어 있습니다.");
                continue;
            }

             Vector3 spawnPos = new Vector3(newX, selected.spawnY, 0f);

            GameObject building = Instantiate(selected.BuildingPrefab, spawnPos, Quaternion.identity, transform);
            building.name = $"Building_{i}_{selected.BuildingPrefab.name}";

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