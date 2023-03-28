using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public bool isFry;
    public bool isCabbage;
    public bool isTomato;
    public bool isBurger;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(isFry)
                DropsManager.instance.fryAmount++;
            if(isCabbage)
                DropsManager.instance.cabbageAmount++;
            if(isTomato)
                DropsManager.instance.tomatoAmount++;
            if(isBurger)
                DropsManager.instance.burgerAmount++;
            Destroy(gameObject);
        }
    }
}
