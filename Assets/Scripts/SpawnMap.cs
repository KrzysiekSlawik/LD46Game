using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[] basicTiles;
    public Transform player;
    private Vector3 lastSpawned;
    private bool isBasic;
    public float distanceToSpawn;
    public float tileWidith;
    public float xTranslation;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        lastSpawned = Vector3.right * xTranslation;
    }
    void FixedUpdate()
    {
        if (player == null) return;
        if(Vector3.Distance(lastSpawned, player.position) < distanceToSpawn)
        {
            SpawnNewTile();
        }
    }
    private void SpawnNewTile()
    {
        lastSpawned += Vector3.forward * tileWidith;
        GameObject prefabToSpawn = isBasic ? basicTiles[Random.Range(0, basicTiles.Length)] :
                                             tiles[Random.Range(0, tiles.Length)];
        Instantiate(prefabToSpawn, lastSpawned, Quaternion.identity);
        isBasic = !isBasic;
    }
}
