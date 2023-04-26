using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DamageTaking : MonoBehaviour
{

    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = 200;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("projectile"))
        {
            if(collision.transform.name == "Shot")
            {
                hp -= 10;
                Destroy(collision.gameObject);
                
            }
            

        }

        if(collision.gameObject.GetComponent<hp>() != null)
        {
            print("intercepted");
            int oldhp = collision.gameObject.GetComponent<hp>().hitpoints;
            collision.gameObject.GetComponent<hp>().hitpoints -= hp;
            hp -= oldhp;
            print(hp);
            print(collision.gameObject.GetComponent<hp>().hitpoints);

            if (collision.gameObject.GetComponent<hp>().hitpoints <= 0)
            {
                Destroy(collision.gameObject);
            }
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    

}
