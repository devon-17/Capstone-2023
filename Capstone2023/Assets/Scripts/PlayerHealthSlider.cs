using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthSlider : MonoBehaviour
{
    public Slider playerSlider;
    
    // Update is called once per frame
    void Update()
    {
        playerSlider.value = PlayerHealth.instance.health;;
    }
}
