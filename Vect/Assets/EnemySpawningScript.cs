using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    public int randomside;
    public GameObject tile;
    public int size;
    public Vector2 randompos;
    public GameObject enemy1;
    public MapSpawnerScript tileinfo;
    public float width;
    public float difficulity;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        difficulity = 5f;
        speed = 2f;
        size = 100;
        width = tile.GetComponent<SpriteRenderer>().bounds.extents.x;
        StartCoroutine(cour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnenemy()
    {
        randomside = Random.Range(1, 5);
        
        if (randomside == 1)
        {
            randompos = new Vector2(1 * width * size, Random.Range(width * size, -width * size));
        }
        else if(randomside == 2)
        {
            randompos = new Vector2(-1 * width * size, Random.Range(width * size, -width * size));
        }
        else if (randomside == 3)
        {
            randompos = new Vector2(Random.Range(width * size, -width * size), 1 * width * size);
        }
        else if (randomside == 4)
        {
            randompos = new Vector2(Random.Range(width * size, -width * size), -1 * width * size);
        }
        else
        {
            print("noob");
        }
       
        
        GameObject enemy = Instantiate(enemy1, randompos*2, Quaternion.identity);
        
        enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1*randompos.x/size, -1*randompos.y / size)*speed;
        enemy.name = "bob";
        
        Vector2 v = enemy.GetComponent<Rigidbody2D>().velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);


    }
    
    IEnumerator cour()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(difficulity);
            spawnenemy();


        }
        
    }

}

