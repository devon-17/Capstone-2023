using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryIntake : MonoBehaviour
{
    HungerSliderController hungerController;


    void Start()
    {
        hungerController = GetComponentInParent<HungerSliderController>();
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            hungerController.hunger += 10;
            Debug.Log("Hunger Up");
        }
    }
}