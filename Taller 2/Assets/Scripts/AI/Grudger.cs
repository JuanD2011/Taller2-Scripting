using UnityEngine;
using System.Collections;

public class Grudger : AI {

    [SerializeField] float minPushDistance;
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

        if (distanceToPlayer <= minPushDistance)
        {
            StartCoroutine(Pushing());

            if (distanceToPlayer <= agent.stoppingDistance)
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

    IEnumerator Pushing() {
        float t = 0f;
        while (t < pursuitTime) {
            t += Time.deltaTime;
            agent.SetDestination(player.position);
            yield return null;
        }
        agent.SetDestination(transform.localPosition);
    }
}
