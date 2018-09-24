using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disease : MonoBehaviour {
    [SerializeField] protected float onSet; //After this time Actor is going to show symptoms
    [SerializeField] protected float TimeUntilDeath; //After this time Actor will be dead;
}
