using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public abstract class Actor : MonoBehaviour {

    bool sickness;
    float sickTime; //Time with sickness (in seconds)
    float timeToDie; //Time left to die (in seconds)

    float probToGetSick = 1f; //Probability to get sick (initially 100%)

    protected Rigidbody m_Rigidbody;//Actor's Rigidbody
    protected Animator m_Animator;//Actor's Animator

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Actor>() != null) {
            float random = Random.Range(0f, 1f);
            if(random <= probToGetSick)
                print("Contagiado");
        }
    }
}
