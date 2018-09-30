using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackDeath : Disease
{
    private float speedDecrease = 0.05f;

    private void Awake()
    {
        onSet = 40f;
        timeUntilDeath = 10f;
        InvokeRepeating("DecreaseSpeed", 1f, 4f);
        InvokeRepeating("Freeze", 1f, 10f);
    }

    private void DecreaseSpeed()
    {
        //El jugador pierde velocidad
    }

    private void Freeze()
    {
        float random = Random.Range(0, 1);
        if (random <= 0.15f)
        {
            //El jugador se queda quieto durante 3 segundos
        }
    }
}
