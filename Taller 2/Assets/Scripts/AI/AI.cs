using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]

public abstract class AI : Actor {

    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get
        {
            return agent;
        }

        set
        {
            agent = value;
        }
    }

    protected virtual void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
}
