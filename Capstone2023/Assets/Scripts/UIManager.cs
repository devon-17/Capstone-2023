using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text fryText, burgerText, lettuceText, tomatoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fryText.text = "x" + DropsManager.instance.fryAmount.ToString();
        burgerText.text = "x" + DropsManager.instance.burgerAmount.ToString();
        lettuceText.text = "x" + DropsManager.instance.cabbageAmount.ToString();
        tomatoText.text = "x" + DropsManager.instance.tomatoAmount.ToString();
    }
}
