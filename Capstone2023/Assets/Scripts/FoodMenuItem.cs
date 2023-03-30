using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenuItem : MonoBehaviour
{
    public bool isFry, isBurger, isBurgerAndFry, isTomAndSalad, isSalad;
    public int fryAmount, burgerAmount, lettuceAmount, tomatoAmount;

    public void Start()
    {
        
    }

    public void MenuClick(FoodMenuItem item)
    {
        if (isFry)
            if(DropsManager.instance.fryAmount >= item.fryAmount)
            {
                //HungerSliderController.instance.hunger += 10;
                Debug.Log("Hunger Added");
            }
    }
}
