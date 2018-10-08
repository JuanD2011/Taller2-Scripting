using UnityEngine;

public class VirusA : Disease
{
    protected float speedDecrease = 0.1f;

    private void Start()
    {
        onSet = 10f;
        timeUntilDeath = 30f;
        type = DiseaseType.VirusA;
        Invoke("ShowSymptoms", onSet);
    }

    protected override void ShowSymptoms()
    {
        print("Muestro síntomas");
        DecreaseActorSpeed(speedDecrease);
        Invoke("KillActor", timeUntilDeath);
    }

    protected virtual void DecreaseActorSpeed(float _percentOfDecrease) {
        print(_percentOfDecrease + "%");
        if (GetComponent<AI>() != null)
        {
            float amountDecreased = GetComponent<AI>().Agent.speed * _percentOfDecrease;
            GetComponent<AI>().Agent.speed -= amountDecreased;
        }
        else if (GetComponent<Player>() != null) {
            float amountDecreased = GetComponent<Player>().MoveSpeed * _percentOfDecrease;
            GetComponent<Player>().MoveSpeed -= amountDecreased;
        }
    }
}
