﻿using System.Collections;
using UnityEngine;

public class VirusS : VirusA
{
    protected float probToGetFreeze;

    protected override void Start()
    {
        base.Start();
        initialOnSet = 30f;
        probToGetFreeze = 0.05f;
        speedDecrease = 0.2f;
        OnSet = initialOnSet;
        TimeUntilDeath = 30f;
        type = DiseaseType.VirusS;
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.red);
        InvokeRepeating("Freeze", 0f, 10f);
        DecreaseActorSpeed(speedDecrease);
    }

    protected void Freeze()
    {
        float random = Random.Range(0f, 1f);
        if(random <= probToGetFreeze)
        {
            //El jugador se queda quieto 2 segundos
            if (GetComponent<AI>() != null)
            {
                AI mAI = GetComponent<AI>();
                mAI.Agent.isStopped = true;
                StartCoroutine(StopMovement(mAI));
            }
            if (GetComponent<Player>() != null)
            {
                Player mPlayer = GetComponent<Player>();
                float actualSpeed = mPlayer.MoveSpeed;
                mPlayer.MoveSpeed = 0f;
                StartCoroutine(StopMovement(mPlayer, actualSpeed));
            }
        }
    }

    protected virtual IEnumerator StopMovement(AI _aI)
    {
        yield return new WaitForSeconds(2f);
        _aI.Agent.isStopped = false;
    }

    protected virtual IEnumerator StopMovement(Player _player, float _actualSpeed)
    {
        yield return new WaitForSeconds(2f);
        _player.MoveSpeed = _actualSpeed;
    }
}
