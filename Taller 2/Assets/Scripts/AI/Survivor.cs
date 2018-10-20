using System.Collections;
using UnityEngine;

public class Survivor : Denizen
{
    protected override void Update()
    {
        base.Update();
        if (isSick)
        {
            StartCoroutine(SearchForVaccines());
        }
    }

    IEnumerator SearchForVaccines()
    {
        RaycastHit hit;
        while (isSick)
        {
            yield return new WaitForSeconds(4);
            if (Physics.SphereCast(transform.localPosition, 10, transform.forward, out hit))
            {
                if (hit.collider.GetComponent<Vaccine>() != null)
                {
                    Agent.SetDestination(hit.transform.position);
                }
            }
        }
    }
}
