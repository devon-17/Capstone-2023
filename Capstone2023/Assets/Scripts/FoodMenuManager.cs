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

    public GameObject menuParent;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerMovement.instance.canMove = false;
            ShowMenu();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuParent.activeInHierarchy)
            {
                menuParent.SetActive(false);
                PlayerMovement.instance.canMove = true;
            }
        }
    }
}
