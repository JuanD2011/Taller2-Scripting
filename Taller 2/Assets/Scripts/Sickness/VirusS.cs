using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusS : Disease
{
    private float speedDecrease = 0.2f;

    private void Awake()
    {
        onSet = 20f;
        timeUntilDeath = 20f;
        InvokeRepeating("Freeze", 1f, 10f);
    }

    private void Freeze()
    {
        float random = Random.Range(0, 1);
        if(random <= 0.05f)
        {
            //El jugador se queda quieto 2 segundos
        }
    }
}
