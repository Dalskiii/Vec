using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DamageTaking : MonoBehaviour
{
    public RescourceScript script;

    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("RescourceManagement").GetComponent<RescourceScript>();
        hp = 20;
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
           
            int oldhp = collision.gameObject.GetComponent<hp>().hitpoints;
            collision.gameObject.GetComponent<hp>().hitpoints -= hp;
            hp -= oldhp;
            if (collision.gameObject.GetComponent<hp>().hitpoints <= 0)
            {
                Destroy(collision.gameObject);
            }
        }

        if(hp <= 0)
        {
            Destroy(gameObject);
            script.addgold(50);
            print("60ad");
        }
    }
    

}
