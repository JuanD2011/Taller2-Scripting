using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackDeath : VirusS
{
    protected override void Start()
    {
        onSet = 40f;
        timeUntilDeath = 10f;
        speedDecrease = 0.05f;
        percentFloat = 0.15f;
        type = DiseaseType.BlackDeath;
        Invoke("ShowSymptoms", onSet);
    }

    protected override void ShowSymptoms()
    {
        InvokeRepeating("DecreaseSpeed", 1f, 4f);
        InvokeRepeating("Freeze", 1f, 10f);
        Invoke("KillActor", timeUntilDeath);
    }

    protected override void DecreaseActorSpeed(float _percentOfDecrease)
    {
        base.DecreaseActorSpeed(_percentOfDecrease);
    }

    protected override IEnumerator StopMovement(AI _aI)
    {
        yield return new WaitForSeconds(3f);
        _aI.Agent.isStopped = false;
    }

    protected override IEnumerator StopMovement(Player _player, float _actualSpeed)
    {
        yield return new WaitForSeconds(3f);
        _player.MoveSpeed = _actualSpeed;
    }
}
