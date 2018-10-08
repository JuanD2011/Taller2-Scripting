using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusS : VirusA
{
    protected float percentFloat;

    protected virtual void Start()
    {
        percentFloat = 0.05f;
        speedDecrease = 0.2f;
        onSet = 5f;
        timeUntilDeath = 20f;
        type = DiseaseType.VirusS;
        Invoke("ShowSymptoms", onSet);
    }

    protected override void ShowSymptoms()
    {
        InvokeRepeating("Freeze", 0f, 10f);
        Invoke("KillActor", timeUntilDeath);
        DecreaseActorSpeed(speedDecrease);
    }

    protected void Freeze()
    {
        float random = Random.Range(0f, 1f);
        print(random);
        if(random <= percentFloat)
        {
            //El jugador se queda quieto 2 segundos
            if (GetComponent<AI>() != null) {
                AI mAI = GetComponent<AI>();
                mAI.Agent.isStopped = true;
                StartCoroutine(StopMovement(mAI));
            }
            if (GetComponent<Player>() != null) {
                Player mPlayer = GetComponent<Player>();
                float actualSpeed = mPlayer.MoveSpeed;
                mPlayer.MoveSpeed = 0f;
                StartCoroutine(StopMovement(mPlayer, actualSpeed));
            }
        }
    }

    protected override void DecreaseActorSpeed(float _percentOfDecrease)
    {
        base.DecreaseActorSpeed(_percentOfDecrease);
    }

    protected virtual IEnumerator StopMovement(AI _aI) {
        yield return new WaitForSeconds(2f);
        _aI.Agent.isStopped = false;
    }

    protected virtual IEnumerator StopMovement(Player _player, float _actualSpeed)
    {
        yield return new WaitForSeconds(2f);
        _player.MoveSpeed = _actualSpeed;
    }
}
