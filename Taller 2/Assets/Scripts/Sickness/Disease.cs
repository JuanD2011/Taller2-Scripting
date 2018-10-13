using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Disease : MonoBehaviour
{
    protected float onSet; //After this time Actor is going to show symptoms
    protected float timeUntilDeath; //After this time Actor will be dead;

    protected DiseaseType type;

    public DiseaseType Type {
        get { return type; }
    }

    protected float speedDecrease;

    protected abstract void ShowSymptoms();

    protected void KillActor() {
        if (GetComponent<AI>() != null)
            Destroy(gameObject);
        else {
            Time.timeScale = 0f;
            print("Game Over");
        }
            
    }

    protected void ChangeColor(Color _color)
    {
        if (GetComponent<AI>() != null)
        {
            GetComponent<MeshRenderer>().material.color = _color;
        }
        else if (GetComponent<Player>() != null)
        {
            PlayerManager.Instance.SkinnedMeshRenderer[1].material.color = _color;
        }
    }

    protected void DecreaseActorSpeed(float _percentOfDecrease)
    {
        print(_percentOfDecrease + "%");
        if (GetComponent<AI>() != null)
        {
            float amountDecreased = GetComponent<AI>().Agent.speed * _percentOfDecrease;
            GetComponent<AI>().Agent.speed -= amountDecreased;
        }
        else if (GetComponent<Player>() != null)
        {
            float amountDecreased = GetComponent<Player>().MoveSpeed * _percentOfDecrease;
            GetComponent<Player>().MoveSpeed -= amountDecreased;
        }
    }
}
