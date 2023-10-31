
using System.Collections;

using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public Ease ease;
    public Tilemap layer1;
    public Tilemap layer2;
    public Tilemap layer3;
    public Tilemap hazardLayer;
    public Vector3 offset;
    public float spriteDelay;
    public float multiplier;
    public ParticleSystem snowSpawnEffect;
    public List<ParticleSystem> particles;
    public void OnEnable()
    {
        particles = new List<ParticleSystem>();
        for (int i = 0; i < 30; i++)
        {
            Instantiate(snowSpawnEffect);
            particles.Add(snowSpawnEffect);
        }
        RevealTiles();



    }
    private void Update()
    {
        multiplier = FindAnyObjectByType<TileManager>().multiplier;
    }

    public void RevealTiles()
    {
        if (Application.isPlaying)
        {
            StartCoroutine(ActiveTileLayer(layer1));
            StartCoroutine(ActiveTileLayer(layer2));
            StartCoroutine(ActiveTileLayer(layer3));
            StartCoroutine(ActiveTileLayer(hazardLayer));

        }


    }
    IEnumerator ActiveTileLayer(Tilemap mapLayer)
    {

        if (mapLayer != null)
        {
            foreach (var position in mapLayer.cellBounds.allPositionsWithin)
            {
                if (mapLayer.HasTile(position))
                {
                    Tile tile = (Tile)mapLayer.GetTile(position);
                    tile.colliderType = Tile.ColliderType.None;
                    tile.color = new Color(255, 255, 255, 0);
                    mapLayer.RefreshTile(position);



                }
            }
            foreach (var position in mapLayer.cellBounds.allPositionsWithin)
            {
                if (mapLayer.HasTile(position))
                {
                    Tile tile = (Tile)mapLayer.GetTile(position);


                    tile.color = new Color(255, 255, 255, 255);
                    tile.colliderType = Tile.ColliderType.Sprite;
                    CreateSprite(tile.sprite, position, spriteDelay);
                    yield return new WaitForSeconds(spriteDelay);
                    if (tile.color != new Color(255, 255, 255, 255))
                    {
                        tile.color = new Color(255, 255, 255, 255);
                        tile.colliderType = Tile.ColliderType.Sprite;
                        CreateSprite(tile.sprite, position, spriteDelay);

                    }
                    if (tile.colliderType != Tile.ColliderType.Sprite) { tile.colliderType = Tile.ColliderType.Sprite; }
                    mapLayer.RefreshTile(position);



                }
            }
        }



    }

    public void CreateSprite(Sprite sprite, Vector3 localPosition, float time)
    {

        var gameObject = new GameObject();
        var spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        gameObject.transform.position = localPosition + offset + new Vector3(0.5f, 3, 0);
        gameObject.transform.DOMoveY(localPosition.y + 1.5f, spriteDelay).SetEase(ease);

      
        if (sprite.name == "snoawtile1" || sprite.name == "snoawtile2" || sprite.name == "snoawtile3")
        {
            int particlenr = 0;
            if (particles[particlenr].isPlaying)
            {
                if(particlenr != particles.Count - 1)
                {
                    particlenr++;
                }
                else
                {
                    particlenr = 0;
                }
               
            }
            particles[particlenr].transform.position = localPosition + offset + new Vector3(0.5f,1,0);
            particles[particlenr].Play();

        }

        spriteRenderer.DOFade(0, 0f);
        spriteRenderer.DOFade(1, 0.3f);
        Destroy(gameObject, time);
    }


}





