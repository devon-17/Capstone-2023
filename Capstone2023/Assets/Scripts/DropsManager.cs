using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsManager : MonoBehaviour
{
    public static DropsManager instance;

    public int fryAmount;
    public int cabbageAmount;
    public int tomatoAmount;
    public int burgerAmount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
