using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuManager : MonoBehaviour
{
    public Transform[] parent = new Transform[0];

    public GameObject[] menuItems = new GameObject[0];

    private Vector3 originalSize;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= menuItems.Length + 1; i++)
        {
            var randomItem = Random.Range(0, menuItems.Length);
            GameObject menuChild = Instantiate(menuItems[randomItem]);
            menuChild.transform.SetParent(parent[i]);
            menuChild.transform.position = parent[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
