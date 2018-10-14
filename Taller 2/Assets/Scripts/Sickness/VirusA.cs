using UnityEngine;

public class VirusA : Disease
{
    private void Start()
    {
        speedDecrease = 0.1f;
        OnSet = 3f;//30
        TimeUntilDeath = 4f;//40
        type = DiseaseType.VirusA;
        Invoke("ShowSymptoms", OnSet);
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.yellow);
        DecreaseActorSpeed(speedDecrease);//speed decreased
    }
}
