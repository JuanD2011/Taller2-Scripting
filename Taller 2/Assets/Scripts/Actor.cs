using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Actor : MonoBehaviour
{
    Disease disease;

    private float sickTime; //Time with sickness (in seconds)
    private float timeToDie; //Time left to die (in seconds)

    private float probToGetA = 1f; //Probability to get sick (initially 100%)
    private float probToGetS = 1f;
    private float probToGetBlackDeath = 1f;

    protected Rigidbody m_Rigidbody;//Actor's Rigidbody
    protected Animator m_Animator;//Actor's Animator

    public delegate void DelActor();
    public DelActor delActor;

    protected virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        disease = GetComponent<Disease>();
        print(disease);

        if (disease != null)
        {
            StartCoroutine(StartSick(disease));
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Actor>() != null) {
            print(string.Format("{0}'s disease: {1}", gameObject.name, disease));
            if (disease != null)
            {
                SetDisease(disease, collision.gameObject.GetComponent<Actor>());
            }
            else {
                disease = GetComponent<Disease>();
                if (disease != null)
                {
                    SetDisease(disease, collision.gameObject.GetComponent<Actor>());
                }
            }
        }
    }

    protected virtual void SetDisease(Disease _disease, Actor _actor) {
        float random = Random.Range(0f, 1f);
        switch (_disease.Type) {
            case DiseaseType.VirusA:
                if (_actor.GetComponent<VirusA>() == null && random <= probToGetA)
                    _actor.gameObject.AddComponent<VirusA>();
                break;
            case DiseaseType.VirusS:
                if (_actor.GetComponent<VirusS>() == null && random <= probToGetS)
                    _actor.gameObject.AddComponent<VirusS>();
                break;
            case DiseaseType.BlackDeath:
                if (_actor.GetComponent<BlackDeath>() == null && random <= probToGetBlackDeath)
                    _actor.gameObject.AddComponent<BlackDeath>();
                break;
            default:
                break;
        }
        if(_actor.disease != null)
            StartCoroutine(_actor.StartSick(_disease));
    }

    IEnumerator StartSick(Disease _disease)
    {
        sickTime = 0f;
        while (sickTime < _disease.OnSet)
        {
            sickTime += Time.deltaTime;
            yield return null;
        }
        delActor();
        StartCoroutine(StartDeath(_disease));
    }

    IEnumerator StartDeath(Disease _disease)
    {
        timeToDie = 0f;
        while (timeToDie < _disease.TimeUntilDeath)
        {
            timeToDie += Time.deltaTime;
            yield return null;
        }
        KillActor();
    }

    private void KillActor()
    {
        if (GetComponent<AI>() != null)
        {
            Destroy(GetComponent<AI>());
            Debug.Log("Desactivado");
        }
        else if(GetComponent<Player>() != null)
        {
            GetComponent<Player>().MoveSpeed = 0f;
            //Time.timeScale = 0f;
            print("Game Over");
        }
    }
}
