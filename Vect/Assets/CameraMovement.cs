using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Color startTileColor;
    public GameObject cam;
    public List<GameObject> tiles = new List<GameObject>();
    public int startcamsize;
    public float currentCamSize;
    void Start()
    {
        startcamsize = (int)cam.GetComponent<Camera>().orthographicSize;
        currentCamSize = (int)cam.GetComponent<Camera>().orthographicSize;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) == true)
        {
            moveCam(0, (int)currentCamSize);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            moveCam(0, (int)-currentCamSize);
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            moveCam((int)-currentCamSize, 0);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            moveCam((int)currentCamSize, 0);
        }
        if (cam.GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel") < startcamsize * 5 && cam.GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel") > 0.5 && Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            
            currentCamSize = cam.GetComponent<Camera>().orthographicSize - Input.GetAxis("Mouse ScrollWheel");
            cam.GetComponent<Camera>().orthographicSize = currentCamSize;
        }



    }
    public void moveCam(int x, int y)
    {
        cam.transform.position = cam.transform.position + new Vector3(x, y, 0) * Time.deltaTime;
        currentCamSize = (int)cam.GetComponent<Camera>().orthographicSize;
    }
}
