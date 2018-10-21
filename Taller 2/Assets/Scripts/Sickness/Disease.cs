using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Disease : MonoBehaviour
{
    private float onSet; //After this time Actor is going to show symptoms
    private float timeUntilDeath; //After this time Actor will be dead;

    protected DiseaseType type;
    protected float speedDecrease;

    public float OnSet
    {
        get
        {
            return onSet;
        }
        set
        {
            onSet = value;
        }
    }
    public float TimeUntilDeath
    {
        get
        {
            return timeUntilDeath;
        }
        set
        {
            timeUntilDeath = value;
        }
    }

    public DiseaseType Type {
        get { return type; }
    }


    protected virtual void Start()
    {
        GetComponent<Actor>().delActor += ShowSymptoms;
    }

    public override string ToString()
    {
        switch (Type)
        {
            case DiseaseType.VirusA:
                return "virusA";
                break;
            case DiseaseType.VirusS:
                return "virusS";
                break;
            case DiseaseType.BlackDeath:
                return "virusBlackDeath";
                break;
            default:
                return "disease";
                break;
        }
    }

    protected abstract void ShowSymptoms();

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
