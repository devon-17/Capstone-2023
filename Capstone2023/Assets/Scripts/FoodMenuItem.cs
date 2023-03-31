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

    void Update()
    {

    }

    public void MenuClick(FoodMenuItem item)
    {
        if (isFry)
            if(DropsManager.instance.fryAmount >= item.fryAmount)
            {
                HungerSliderController.instance.hunger += FoodMenuManager.instance.fryHungerAmount; 
                Debug.Log("Hunger Added");
                DropsManager.instance.fryAmount -= item.fryAmount;
                Destroy(gameObject);
            }
        if (isBurger)
            if(DropsManager.instance.burgerAmount >= item.burgerAmount)
            {
                HungerSliderController.instance.hunger += FoodMenuManager.instance.burgerHungerAmount;
                Debug.Log("Hunger Added");
                DropsManager.instance.burgerAmount -= item.burgerAmount;
                Destroy(gameObject);
            }
        if (isBurgerAndFry)
            if(DropsManager.instance.burgerAmount >= item.burgerAmount && DropsManager.instance.fryAmount >= item.fryAmount)
            {
                HungerSliderController.instance.hunger += (FoodMenuManager.instance.fryHungerAmount + FoodMenuManager.instance.burgerHungerAmount);
                Debug.Log("Hunger Added");
                DropsManager.instance.fryAmount -= item.fryAmount;
                DropsManager.instance.burgerAmount -= item.burgerAmount;
                Destroy(gameObject);
            }
        if (isTomAndSalad)
            if(DropsManager.instance.tomatoAmount >= item.tomatoAmount && DropsManager.instance.cabbageAmount >= item.lettuceAmount)
            {
                HungerSliderController.instance.hunger += (FoodMenuManager.instance.lettuceHungerAmount + FoodMenuManager.instance.tomatoHungerAmount);
                Debug.Log("Hunger Added");
                DropsManager.instance.tomatoAmount -= item.tomatoAmount;
                DropsManager.instance.cabbageAmount -= item.lettuceAmount;
                Destroy(gameObject);
            }
        if (isSalad)
            if(DropsManager.instance.cabbageAmount >= item.lettuceAmount)
            {
                HungerSliderController.instance.hunger += FoodMenuManager.instance.lettuceHungerAmount;
                Debug.Log("Hunger Added");
                DropsManager.instance.cabbageAmount -= item.lettuceAmount;
                Destroy(gameObject);
            }
        
    }
}
