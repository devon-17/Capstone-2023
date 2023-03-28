using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HungerSliderController : MonoBehaviour
{

    public Slider mySlider;
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
        mySlider.value = hunger;
        hunger -= Time.deltaTime;
    }
}
