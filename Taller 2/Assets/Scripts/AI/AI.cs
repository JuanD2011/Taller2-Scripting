using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class AI : Actor
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get
        {
            return agent;
        }
    }

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }
}
