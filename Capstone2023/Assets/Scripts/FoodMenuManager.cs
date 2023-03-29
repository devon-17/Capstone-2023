using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuManager : MonoBehaviour
{
    public static FoodMenuManager instance;

    public Transform[] parent = new Transform[0];

    public GameObject[] menuItems = new GameObject[0];

    private Vector3 originalSize;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowMenu()
    {
        for (int i = 0; i < parent.Length; i++)
        {
            var randomItem = Random.Range(0, menuItems.Length);
            GameObject menuChild = Instantiate(menuItems[randomItem]);
            menuChild.transform.SetParent(parent[i]);
            menuChild.transform.position = parent[i].position;
        }
    }
}
