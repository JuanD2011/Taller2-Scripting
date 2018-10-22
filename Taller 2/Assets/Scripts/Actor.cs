using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public abstract class Actor : MonoBehaviour
{
    protected Disease disease;

    private float sickTime; //Time with sickness (in seconds)
    private float timeToDie; //Time left to die (in seconds)

    private float probToGetA = 1f; //Probability to get sick (initially 100%)
    private float probToGetS = 1f;
    private float probToGetBlackDeath = 1f;

    protected Rigidbody m_Rigidbody;//Actor's Rigidbody
    protected Animator m_Animator;//Actor's Animator

    public delegate void DelActor();
    public DelActor delActor;

    public delegate void GameState();
    public static event GameState OnGameOver;

    public float ProbToGetA
    {
        get
        {
            return Mathf.Clamp(probToGetA, 0.4f, 1);
        }

        set
        {
            if (value < 0.4f)
            {
                probToGetA = 0.4f;
            }
            else
            {
                probToGetA = value;
            }
        }
    }

    public float ProbToGetS
    {
        get
        {
            return Mathf.Clamp(probToGetS, 0.4f, 1);
        }

        set
        {
            if (value < 0.4f)
            {
                probToGetS = 0.4f;
            }
            else
            {
                probToGetS = value;
            }
        }
    }

    public float ProbToGetBlackDeath
    {
        get
        {
            return Mathf.Clamp(probToGetBlackDeath, 0.4f, 1);
        }

        set
        {
            if(value < 0.4f)
            {
                probToGetBlackDeath = 0.4f;
            }
            else
            {
                probToGetBlackDeath = value;
            }
        }
    }

    protected virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        Invoke("Holi", 0f);
    }

    private void Holi()
    {
        disease = GetComponent<Disease>();

        if (disease != null)
        {
            StartCoroutine(StartSick(disease));
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Actor actor = collision.gameObject.GetComponent<Actor>();
        if (actor != null)
        {
            if (actor.GetComponent<Disease>() == null) {
                if (disease != null)
                {
                    SetDisease(disease, actor);
                }
            }
            //print(string.Format("{0}'s disease: {1}", gameObject.name, disease));
        }

        if(collision.gameObject.GetComponent<Vaccine>())
        {
            Vaccine vaccine = collision.gameObject.GetComponent<Vaccine>();

            switch (vaccine.TypeVaccine)
            {
                case DiseaseType.VirusA:
                    ProbToGetA -= ProbToGetA * vaccine.Immunity;

                    if (disease != null)
                    {
                        if (disease.Type == DiseaseType.VirusA)
                        {
                            disease.OnSet -= disease.OnSet * 0.1f;
                            sickTime = 0f;
                            timeToDie = 0f;
                            StopAllCoroutines();
                            Destroy(disease);
                        } 
                    }
                    break;

                case DiseaseType.VirusS:
                    ProbToGetS = ProbToGetS - ProbToGetS * vaccine.Immunity;

                    if (disease != null)
                    {
                        if (disease.Type == DiseaseType.VirusS && disease != null)
                        {
                            disease.OnSet -= disease.OnSet * 0.1f;
                            sickTime = 0f;
                            timeToDie = 0f;
                            StopAllCoroutines();
                            Destroy(disease);
                        } 
                    }
                    break;
                default:
                    break;
            } 

            Destroy(vaccine.gameObject);
        }
    }

    protected virtual void SetDisease(Disease _disease, Actor _actor)
    {

        float random = Random.Range(0f, 1f);

        switch (_disease.Type)
        {
            case DiseaseType.VirusA:
                if (_actor.GetComponent<VirusA>() == null && random <= ProbToGetA)
                {
                    _actor.gameObject.AddComponent<VirusA>();
                    _actor.disease = _actor.GetComponent<Disease>();
                }
                break;
            case DiseaseType.VirusS:
                if (_actor.GetComponent<VirusS>() == null && random <= ProbToGetS)
                {
                    _actor.gameObject.AddComponent<VirusS>();
                    _actor.disease = _actor.GetComponent<Disease>();
                }
                break;
            case DiseaseType.BlackDeath:
                if (_actor.GetComponent<BlackDeath>() == null && random <= ProbToGetBlackDeath)
                {
                    _actor.gameObject.AddComponent<BlackDeath>();
                    _actor.disease = _actor.GetComponent<Disease>();
                }
                break;
            default:
                break;
        }

        StartCoroutine(_actor.StartSick(_disease));
    }

    IEnumerator StartSick(Disease _disease)
    {
        sickTime = 0f;
        print(_disease.OnSet);
        while (sickTime < _disease.OnSet)
        {
            sickTime += Time.deltaTime;
            yield return null;
        }
        if (disease != null)
        {
            delActor(); 
            StartCoroutine(StartDeath(_disease));
        }
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
            disease.CancelInvoke("Freeze");
            CancelInvoke("GetVaccine");
            Destroy(gameObject);
        }
        else if(GetComponent<Player>() != null)
        {
            GetComponent<Player>().MoveSpeed = 0f;
            //Time.timeScale = 0f;
            OnGameOver();
        }
    }
}
