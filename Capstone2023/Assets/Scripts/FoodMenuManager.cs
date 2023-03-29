using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuManager : MonoBehaviour
{
    public GameObject parentCanvas;
    public GameObject[] menuItems = new GameObject[0];
    private Vector3 originalSize;

    // Start is called before the first frame update
    void Start()
    {
        GameObject menuChild = Instantiate(menuItems[0]);
        // originalSize = menuChild.transform.scale;
        menuChild.transform.parent = parentCanvas.transform;
        //menuChild.transform.localScale = originalSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
