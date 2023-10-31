using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public GameObject[] TileMap;
    public float multiplier = 0f;
    int currentPlattform;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    public void SpawnChunk(Transform currentChunkTransform)
    {
       TileMap[currentPlattform].GetComponent<Chunk>().layer1.CompressBounds();
       Vector3Int tileSize = TileMap[currentPlattform].GetComponent<Chunk>().layer1.size;
        Debug.Log(tileSize);
        GameObject newTileMap = Instantiate(TileMap[currentPlattform], currentChunkTransform.position + tileSize, Quaternion.identity);
        newTileMap.GetComponent<Chunk>().offset = tileSize;
      
       
        currentPlattform++;
        
       
    }
    public void UpdateMultiplier()
    {
       
        multiplier++;
    }
}
