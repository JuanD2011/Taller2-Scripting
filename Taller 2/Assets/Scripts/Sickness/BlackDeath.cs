using System.Collections;
using UnityEngine;

public class BlackDeath : VirusS
{
    protected override void Start()
    {
        base.Start();
        initialOnSet = 40f;
        OnSet = initialOnSet;
        TimeUntilDeath = 5f;
        speedDecrease = 0.05f;
        probToGetFreeze = 0.15f;
        type = DiseaseType.BlackDeath;
        InvokeRepeating("Freeze", 0f, 10f);
        Invoke("GetComponents", 0f);
    }

    private void GetComponents()
    {
        if (GetComponent<AI>() != null)
        {
            AI aI = GetComponent<AI>();
            StartCoroutine(DecreaseSpeed(aI));
        }
        else if (GetComponent<Player>() != null)
        {
            Player player = GetComponent<Player>();
            StartCoroutine(DecreaseSpeed(player));
        }
    }

    protected override void ShowSymptoms()
    {
        ChangeColor(Color.black);
        probToGetFreeze = 1f;
        Invoke("Freeze", 0);
    }

    IEnumerator DecreaseSpeed(AI _aI)
    {
        float speed = 0f;
        speed = _aI.Agent.speed;
        float fortyPercent = speed * 0.4f;
        while (_aI.Agent.speed > speed - fortyPercent)
        {
            DecreaseActorSpeed(speedDecrease);
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator DecreaseSpeed(Player _player)
    {
        float speed = 0f;
        speed = _player.MoveSpeed;
        float fortyPercent = speed * 0.4f;
        while (_player.MoveSpeed > speed - fortyPercent)
        {
            DecreaseActorSpeed(speedDecrease);
            yield return new WaitForSeconds(4f);
        }
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
