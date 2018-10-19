using UnityEngine;
using System.Collections;

public class Grudger : AI
{
    [SerializeField] float minPursuitDistance;
    [SerializeField] float pursuitTime;

    private float distanceToPlayer;
    private Transform player;
    Vector3 direction;
    Quaternion lookRotation;

    protected override void Start()
    {
        base.Start();
        player = PlayerManager.Instance.player.transform;
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(player.localPosition, transform.localPosition);

        if (distanceToPlayer <= minPursuitDistance)
        {
            StartCoroutine(Pursuit());

            if (distanceToPlayer <= Agent.stoppingDistance)
            {
                LookAt(player);
            }
        }
    }

    private void LookAt(Transform _target)
    {
        direction = (_target.position - transform.localPosition).normalized;
        lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator Pursuit()
    {
        float t = 0f;
        while (t < pursuitTime)
        {
            t += Time.deltaTime;
            Agent.SetDestination(player.position);
            yield return null;
        }
        Agent.SetDestination(transform.localPosition);
    }
}
