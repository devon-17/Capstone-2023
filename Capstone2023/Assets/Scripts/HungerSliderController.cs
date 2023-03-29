using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HungerSliderController : MonoBehaviour
{

    public Slider hungerSlider;
    public float hunger;
    public float maxHunger = 100;

    // Start is called before the first frame update
    void Start()
    {
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        hungerSlider.value = hunger;
        hunger -= Time.deltaTime;
        if(hunger > maxHunger)
        {
            hunger = 100;
        }
    }
}
