using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GenerateMap();
    }

    public GameObject TilePrefab;

    public Mesh MeshDeepWater;
    public Mesh MeshShallowWater;
    public Mesh MeshCoast;
    public Mesh MeshFlat;
    public Mesh MeshHill;
    public Mesh MeshMountain;

    public Material MatOcean;
    public Material MatPlains;
    public Material MatGrasslands;
    public Material MatMountains;

    public readonly int numRows = 60;
    public readonly int numColumns = 120;

    private Tile[,] tiles;

    public Tile GetTileAt(int x, int y)
    {
        if (tiles == null)
        {
            Debug.LogError("Tiles array not yet instantiated");
            return null;
        }

        return tiles[x, y];
    }

    virtual public void GenerateMap()
    {
        // Generate a map filled with ocean

        tiles = new Tile[numRows, numColumns];
        tileToGameObjectMap = new Dictionary<Tile, GameObject>();

        for (int column = 0; column < numColumns; column++)
        {
            for (int row = 0; row < numRows; row++)
            {
                Tile t = new Tile(column, row);
                t.Elevation = -1;

                GameObject tileGO = (GameObject)Instantiate(
                    TilePrefab,
                    t.Position(),
                    Quaternion.identity,
                    this.transform
                    );

                //TileGO.GetComponent<TileComponent>().Tile = t;
                //TileGO.GetComponent<TileComponent>().TileMap = this;

                tileGO.GetComponentInChildren<TextMesh>().text = string.Format("{0},{1}", column, row);


            }
        }

    }

    public void UpdateTileVisuals()
    {
        for (int column = 0; column < numColumns; column++)
        {
            for (int row = 0; row < numRows; row++)
            {
                Tile t = tiles[column,row];
                GameObject tileGo = tileToGameObjectMap[t];
                MeshRenderer mr = tileGO.GetComponentInChildren<MeshRenderer>();
                if (t.Elevation >= 0)
                {
                    mr.material = MatGrasslands;
                }
                else
                {
                    mr.material = MatOcean;
                }

                MeshFilter mf = tileGO.GetComponentInChildren<MeshFilter>();
                mf.mesh = MeshDeepWater;
            }
        }
        StaticBatchingUtility.Combine(this.gameObject);
    }
}
