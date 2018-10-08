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

    protected abstract void ShowSymptoms();

    protected void KillActor() {
        print("Muero");
        Destroy(gameObject);
    }
}
