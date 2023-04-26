using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawnerScript : MonoBehaviour
{
    public GameObject Corner;
    public GameObject NotCorner;
    public GameObject tile;
    public float width;
    public GameObject camscript;
    public int size;
    
    // Start is called before the first frame update
    void Start()
    {
        size = 20;
        width = tile.GetComponent<SpriteRenderer>().bounds.extents.x;
        spawnTiles(size);
        camscript.GetComponent<CameraMovement>().startTileColor = tile.GetComponent<SpriteRenderer>().color;
        foreach (GameObject Obj in GameObject.FindGameObjectsWithTag("Tile"))
        {
            camscript.GetComponent<CameraMovement>().tiles.Add(Obj);
        }
        basespawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void spawnTiles(int mapsize)
    {
       for(int x = 0;x < mapsize; x++)
        {
            for(int y = 0; y < mapsize; y++)
            {

                spawnTile(x, y, true, false);
                spawnTile(-x, y, false,true);
                spawnTile(x, -y, false,false);
                spawnTile(-x, -y, true,false);
            }
        }
    }
    void spawnTile(int x,int y, bool Border, bool Middle)
    {
        GameObject tile2;

        if (Border == true)
        {
            if (x == 0)
            {}
            else if(y == 0)
            {}
            else
            {
                tile2 = Instantiate(tile, new Vector3(x * width * 2, y * width * 2, 0), tile.transform.rotation);
                tile2.name = x.ToString() + "," + y.ToString();
            }
           
        
        }
        else if(Middle == true)
        {
            if(x == 0 && y == 0)
            {}
            else
            {
                tile2 = Instantiate(tile, new Vector3(x * width * 2, y * width * 2, 0), tile.transform.rotation);
                tile2.name = x.ToString() + "," + y.ToString();
            }
        }
        else
        {
            tile2 = Instantiate(tile, new Vector3(x * width * 2, y * width * 2, 0), tile.transform.rotation);
            tile2.name = x.ToString() + "," + y.ToString();

        }



    }

    public void basespawn()
    {
        string[] bases = { "0,0", "1,1", "-1,1", "-1,-1", "0,1", "1,0", "-1,0", "0,-1", "1,-1" };
        foreach (string cord in bases)
        {
            
            GameObject efef = Instantiate(Corner, GameObject.Find(cord).transform);
            efef.GetComponent<SpriteRenderer>().sortingOrder = 1;
            efef.transform.position = efef.transform.parent.position;
        }
    }
}
