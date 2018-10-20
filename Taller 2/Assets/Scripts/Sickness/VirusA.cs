using UnityEngine;

public class VirusA : Disease
{
    protected override void Start()
    {
        base.Start();
        speedDecrease = 0.1f;
        OnSet = 3f;//30
        TimeUntilDeath = 4f;//40
        type = DiseaseType.VirusA;
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.green);
        DecreaseActorSpeed(speedDecrease);//speed decreased
    }
}
