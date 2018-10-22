using UnityEngine;

public class VirusA : Disease
{

    protected override void Start()
    {
        base.Start();
        initialOnSet = 20f;
        speedDecrease = 0.1f;
        OnSet = initialOnSet;//30
        TimeUntilDeath = 40f;//40
        type = DiseaseType.VirusA;
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.green);
        DecreaseActorSpeed(speedDecrease);//speed decreased
    }
}
