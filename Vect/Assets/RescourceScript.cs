using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescourceScript : MonoBehaviour
{
    public int gold;
    public GameObject UI;
    void Start()
    {
        gold = 200;
        updateGold();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateGold()
    {
        UI.transform.Find("GoldText").GetComponent<Text>().text = "Gold: " + gold.ToString();
    }

    public void addgold(int amount)
    {
        gold += amount;
        updateGold();
    }
}
