using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject enemytoshoot;
    public GameObject bullet;
    public float range = 5;
    // Start is called before the first frame update
    void Start()
    {
        range = 5;
        StartCoroutine(Cour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnshot(Vector2 enemypos)
    {
        float bounds = gameObject.transform.Find("SpriteHolder").GetComponent<SpriteRenderer>().bounds.extents.x;
        Vector2 turretpos = gameObject.transform.position;

        GameObject bul = Instantiate(bullet, turretpos, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().velocity = (enemypos - turretpos) / (enemypos - turretpos).magnitude * 10;
        Vector2 dir = enemypos - turretpos;
        float rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bul.name = "Shot";

        gameObject.transform.Find("SpriteHolder").Find("TurretRot").rotation = Quaternion.Euler(0, 0, rot-90);

    }

    IEnumerator Cour()
    {
        while (true)
        {
            
            float pos = Mathf.Infinity;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
            {
                if ((enemy.transform.position - gameObject.transform.position).magnitude < pos && (enemy.transform.position - gameObject.transform.position).magnitude < range && gameObject.GetComponent<Collider2D>().enabled)
                {
                    pos = (enemy.transform.position - gameObject.transform.position).magnitude;
                    enemytoshoot = enemy;
                    print("spotted");
                }
            }

            if (enemytoshoot != null && (enemytoshoot.transform.position - gameObject.transform.position).magnitude < range && enemytoshoot.CompareTag("enemy"))
            {
                spawnshot(enemytoshoot.transform.position);
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(0.1f);

        }

    }
}
