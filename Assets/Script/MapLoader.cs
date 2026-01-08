using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public Sprite GroundSprite;
    public Vector2 StartPosition = Vector2.zero;
    public float Spacing = 1f;
    public int TileCount = 100;
 
    // Start is called before the first frame update
    void Start()
    {
        if (GroundSprite == null)
        {
            Debug.LogWarning("GroundSprite is not assigned.");
            return;
        }

        for (int i = 0; i < TileCount; i++)
        {
            var tile = new GameObject($"GroundTile_{i}");
            tile.transform.parent = transform;
            tile.transform.position = new Vector3(StartPosition.x + Spacing * i, StartPosition.y, 0f);

            var renderer = tile.AddComponent<SpriteRenderer>();
            renderer.sprite = GroundSprite;

            // BoxCollider2D 추가
            var collider = tile.AddComponent<BoxCollider2D>();

            // 스프라이트 크기에 맞게 콜라이더 사이즈 조정 (픽셀 퍼 유닛 기준)
            if (renderer.sprite != null)
            {
                collider.size = renderer.sprite.bounds.size;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
