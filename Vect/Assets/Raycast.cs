using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Raycast : MonoBehaviour
{
    public Button BuildMenu;
    public bool placeObj = false;
    public GameObject Turret;
    public GameObject SpriteHolder;
    public GameObject Eventsystem;
    Collider2D hit;
    GameObject hitObject;
    
    public Vector3 mousePos;
    public Camera cam;
    public GameObject tempObject;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Physics2D.OverlapPoint(new Vector2(mousePos.x, mousePos.y)) != null)
        {
            hit = Physics2D.OverlapPoint(new Vector2(mousePos.x, mousePos.y));
            hitObject = hit.gameObject;
           
        }

        if (placeObj == true && hitObject.CompareTag("Tile"))
        {
            tempObject.transform.position = hitObject.transform.position;
            SpriteHolder.GetComponent<SpriteRenderer>().color = new Color(SpriteHolder.GetComponent<SpriteRenderer>().color.r, SpriteHolder.GetComponent<SpriteRenderer>().color.g, SpriteHolder.GetComponent<SpriteRenderer>().color.b, 130);
        }



        if (Input.GetMouseButton(0) && placeObj && !IsPointerOverUIObject() && hitObject.transform.childCount <= 0 && hitObject.transform.parent == null && hitObject.CompareTag("Tile"))
        {
            placeObj = false;
            tempObject.GetComponent<Collider2D>().enabled = true;
            print(Turret.GetComponent<Collider2D>().enabled);
            print("noob");
            tempObject.transform.parent = hitObject.transform;
        }
        
    }
    public void setPlaceObj()
    {
        if(placeObj == false)
        {
            Turret.GetComponent<Collider2D>().enabled = false;
            placeObj = true;
            tempObject = Instantiate(Turret, hitObject.transform);
            SpriteHolder = tempObject.transform.Find("SpriteHolder").gameObject;
            tempObject.GetComponent<Collider2D>().enabled = false;

        }
        else
        {
            placeObj = false;
            Destroy(tempObject);
        }
    }
    private bool IsPointerOverUIObject()
    {
        if (EventSystem.current == null)
            return false;

        return EventSystem.current.IsPointerOverGameObject();
        
    }
    


}
