using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSpawnerScript : MonoBehaviour
{
    public Sprite newsprite;
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
        spawnRescources(size);
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

    public void spawnRescources(int mapsize)
    {
        print(mapsize);
        for(float  i = -mapsize+1; i < mapsize; i++) { 
            for(float j = -mapsize+1; j < mapsize; j++)
            {
                print(mapsize);
                print(Mathf.PerlinNoise(Random.Range(i + i / 5, i - i / 5), Random.Range(j + j / 5, j - j / 5)));
                if (Mathf.PerlinNoise(Random.Range(i + (i/8), i - (i/8)), Random.Range(j + (j/8), j - (j/8))) < 0.4f)
                {
                    print(i.ToString() + "," + j.ToString());
                    GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().sprite = newsprite;
                    GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().size = new Vector2(1f, 1f);
                    GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().color = new Color(255, 215, 0);
                    

                }
            }

        }
    }
}
