using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapSpawnerScript : MonoBehaviour
{
    public Sprite newsprite;
    public GameObject Corner;
    public GameObject NotCorner;
    public GameObject tile;
    public float width;
    public GameObject camscript;
    public int size;
    public float seed;
    public float scale;
    public float lessthan;



    // Start is called before the first frame update
    void Start()
    {
        lessthan = 0.3f;
        scale = 0.1f;
        Random.Range(0, 100000);
        size = 100;
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
                float randomi = Random.Range(-i, i)/20;
                float randomj = Random.Range(-j, j)/20;
                print(Mathf.PerlinNoise(i / size, j / size));

                if(i < 0 && j < 0)
                {
                    if (Mathf.PerlinNoise(i * scale, j * scale) < lessthan)
                    {

                        GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().sprite = newsprite;


                    }
                }
                else if (i<0 && j > 0)
                {
                    if (Mathf.PerlinNoise(i * scale+1000, j * scale+1000) < lessthan)
                    {

                        GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().sprite = newsprite;


                    }

                }
                else if (i > 0 && j > 0)
                {
                    if (Mathf.PerlinNoise(i * scale+100000, j * scale + 100000) < lessthan)
                    {

                        GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().sprite = newsprite;


                    }

                }
                else if (i > 0 && j < 0)
                {
                    if (Mathf.PerlinNoise(i * scale+10000, j * scale+10000) < lessthan)
                    {

                        GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().sprite = newsprite;


                    }

                }
                else
                {
                    if (Mathf.PerlinNoise(i * scale + 100, j * scale + 100) < lessthan)
                    {

                        GameObject.Find(i.ToString() + "," + j.ToString()).GetComponent<SpriteRenderer>().sprite = newsprite;


                    }

                }
            }

        }
    }
}
