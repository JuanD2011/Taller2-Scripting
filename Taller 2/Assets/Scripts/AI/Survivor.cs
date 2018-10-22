using UnityEngine;

public class Survivor : Denizen
{
    protected override void Update()
    {
        base.Update();
    }

    protected override void SetDisease(Disease _disease, Actor _actor)
    {
        base.SetDisease(_disease, _actor);
        InvokeRepeating("GetVaccine", 0, 4);
    }

    private void GetVaccine()
    {
        if (disease != null)
        {
            RaycastHit hit;
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
