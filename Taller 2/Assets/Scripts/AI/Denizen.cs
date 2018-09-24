using UnityEngine;

public class Denizen : AI {
    
    [SerializeField] Transform[] points;
    private int destination = 0;

    protected override void Start()
    {
        base.Start();

        foreach (Transform a in points) {
            a.parent = null;
        }

        agent.autoBraking = false;
        GotoNextPoint();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        if (points.Length == 0)
            Debug.LogError("Assign waypoints");
        else
        {
            agent.destination = points[destination].position;
            destination = (destination + 1) % points.Length;
        }
    }
}