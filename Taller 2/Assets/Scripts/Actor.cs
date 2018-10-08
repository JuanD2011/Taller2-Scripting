using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public abstract class Actor : MonoBehaviour {

    [SerializeField] protected bool sickness;
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
            if (random <= probToGetSick && GetComponent<Disease>()!= null) {
                Disease disease = GetComponent<Disease>();
                SetDisease(disease, collision.gameObject.GetComponent<Actor>());
                print("Contagiado");
            }
        }
    }

    private void SetDisease(Disease _disease, Actor _actor) {
        switch (_disease.Type) {
            case DiseaseType.VirusA:
                if(_actor.GetComponent<VirusA>() == null)
                    _actor.gameObject.AddComponent<VirusA>();
                break;
            case DiseaseType.VirusS:
                if (_actor.GetComponent<VirusS>() == null)
                    _actor.gameObject.AddComponent<VirusS>();
                break;
            case DiseaseType.BlackDeath:
                if (_actor.GetComponent<BlackDeath>() == null)
                    _actor.gameObject.AddComponent<BlackDeath>();
                break;
            default:
                break;
        }

    }
}
