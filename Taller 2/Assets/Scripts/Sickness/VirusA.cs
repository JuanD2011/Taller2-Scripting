using UnityEngine;

public class VirusA : Disease
{
    protected override void Start()
    {
        base.Start();
        speedDecrease = 0.1f;
        OnSet = 30f;//30
        TimeUntilDeath = 40f;//40
        type = DiseaseType.VirusA;
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.green);
        DecreaseActorSpeed(speedDecrease);//speed decreased
    }
}
