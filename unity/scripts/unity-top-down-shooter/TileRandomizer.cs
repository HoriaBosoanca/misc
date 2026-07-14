using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using NavMeshPlus.Components;

public class TileRandomizer : MonoBehaviour
{
    [Header("!!! Manual Refrences")]
    [SerializeField] private Tile flowers;
    [SerializeField] private Tile brick;
    [SerializeField] private GameObject crate;

    [Header("Editable")]
    [SerializeField] private float chanceToGeneratePerTile;
    [SerializeField] private int mapSize;
    [SerializeField] private string structureToGenerate;
    [SerializeField] private bool randomRotation;
    [SerializeField] private int tilesToBeApart;

    //refs
    private Tilemap tilemap;
    private NavMeshSurface Surface2D; 

    //vars
    private Vector3Int center;
    private bool bakeAfterGeneration;
    private List<Vector3Int> allCenters;
    private int flipX;
    private int flipY;
    void Awake()
    {
        tilemap = gameObject.GetComponent<Tilemap>();
        Surface2D = GameObject.Find("BakeNavMesh").GetComponent<NavMeshSurface>(); // !!! NavMesh Generator needs to be named "BakeNavMesh"
        allCenters = new List<Vector3Int>();

        float amount = chanceToGeneratePerTile * mapSize*mapSize;
        for (int i = 1; i <= amount; i++)
        {
            Flowers();
            House();
        }
    }

    void Start()
    {
        if(GetComponent<Rigidbody2D>() != null) // rebuild navmesh if Rigidbody2D is found
        {
            bakeAfterGeneration = true;
        }
        if(bakeAfterGeneration)
        {
            Surface2D.BuildNavMeshAsync();
        }
    }

    void Flowers()
    {
        if(structureToGenerate == "Flowers")
        {
            center = rPos(); //gets center of buid

            Build(0,0,flowers);
        }
    }

    void House()
    {
        if(structureToGenerate == "Corner")
        {
            center = rPos(); //gets center of build

            flipX = Flip(); // 50% chance to flip, if necessary
            flipY = Flip();

            if(CheckDistance(center)) // makes sure structure won't spawn on top of another of the same type
            {
                return;
            } 

            Build(-3,1,brick); //left wall
            Build(-3,0,brick);
            Build(-3,-1,brick);

            ObjectChanceBuild(-2,-1,crate,0.5f);
            ObjectChanceBuild(-2,1,crate,0.5f);

            Build(0,3,brick); //up wall
            Build(-1,3,brick);
            Build(1,3,brick);

            ObjectChanceBuild(-1,2,crate,0.5f);
            ObjectChanceBuild(1,2,crate,0.5f);

            Build(-2,2,brick);
            Build(2,2,brick);
            Build(-2,-2,brick);
        }
    }
    
    // operations
    void Build(int offsetX, int offsetY, Tile tile)
    {
        tilemap.SetTile(new Vector3Int(center.x + offsetX * flipX, center.y + offsetY * flipY, center.z), tile);
    }

    void ObjectChanceBuild(int offsetX, int offsetY, GameObject g, float chance)
    {
        if (Random.value < chance)
        {
            Instantiate(g, new Vector3Int(center.x + offsetX * flipX, center.y + offsetY * flipY, center.z), Quaternion.identity);
        }
    }

    int Flip()
    {
        if(randomRotation)
        {
            if(Random.value < 0.5f)
            {
                return -1;
            }
        }
        return 1;
    }

    Vector3Int rPos()
    {
        Vector3Int tilePosX;
        tilePosX = tilemap.WorldToCell(new Vector3Int(Random.Range(-mapSize, mapSize), Random.Range(-mapSize, mapSize), 0));
        return tilePosX;
    }

    bool CheckDistance(Vector3Int center_)
    {
        foreach(Vector3Int i in allCenters)
        {
            if(Mathf.Abs(center_.x - i.x) <= tilesToBeApart || Mathf.Abs(center_.y - i.y) <= tilesToBeApart)
            {
                return true;
            }
        }

        allCenters.Add(center_);
        
        return false;
    }
}
