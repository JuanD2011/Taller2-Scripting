using UnityEngine;

public class VirusA : Disease
{
    private void Start()
    {
        speedDecrease = 0.1f;
        onSet = 30f;
        timeUntilDeath = 40f;
        type = DiseaseType.VirusA;
        Invoke("ShowSymptoms", onSet);
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.yellow);
        DecreaseActorSpeed(speedDecrease);//speed decreased
        Invoke("KillActor", timeUntilDeath);//Start time to die
    }
}
