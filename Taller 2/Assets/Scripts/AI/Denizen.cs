using UnityEngine;

public class Denizen : AI
{    
    [SerializeField] protected Transform[] points;
    private int destination = 0;

    protected override void Start()
    {
        base.Start();

        foreach (Transform a in points)
        {
            a.parent = null;
        }

        Agent.autoBraking = false;
        GotoNextPoint();
    }

    protected virtual void Update()
    {
        if (Agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        if (points.Length == 0)
            Debug.LogError("Assign waypoints");
        else
        {
            Agent.destination = points[destination].position;
            destination = (destination + 1) % points.Length;
        }
    }
}