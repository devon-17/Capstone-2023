using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodMenuManager : MonoBehaviour
{
    public static FoodMenuManager instance;

    public bool menuCreated = false;

    public Transform[] parent = new Transform[0];

    public GameObject[] menuItems = new GameObject[0];

    public GameObject menuParent;

    public GameObject enterBtn;

    public GameObject exitBtn;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        menuCreated = false;
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
        if (other.gameObject.tag == "Player")
        {
            enterBtn.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        enterBtn.SetActive(false);
    }

    public void EnterMenu()
    {
        PlayerMovement.instance.canMove = false;
        PlayerAttack.instance.attacking = false;
        if (!menuCreated)
        {
            ShowMenu();
            menuCreated = true;
        }
        else
            menuParent.SetActive(true);
        exitBtn.SetActive(true);
        enterBtn.SetActive(false);
    }

    public void ExitMenu()
    {
        PlayerMovement.instance.canMove = true;
        PlayerAttack.instance.attacking = true;
        menuParent.SetActive(false);
        exitBtn.SetActive(false);
        enterBtn.SetActive(true);
    }
}
