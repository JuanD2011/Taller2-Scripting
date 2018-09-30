using UnityEngine;

public class VirusA : Disease
{
    private float speedDecrease = 0.1f;

    private void Awake()
    {
        onSet = 10f;
        timeUntilDeath = 30f;
    }
}
