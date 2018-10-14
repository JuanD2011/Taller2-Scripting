using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public abstract class Actor : MonoBehaviour {

    float sickTime; //Time with sickness (in seconds)
    float timeToDie; //Time left to die (in seconds)

    float probToGetSick = 1f; //Probability to get sick (initially 100%)

    protected Rigidbody m_Rigidbody;//Actor's Rigidbody
    protected Animator m_Animator;//Actor's Animator

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        //if (GetComponent<Disease>() != null)
          //  StartCoroutine(StartSick(GetComponent<Disease>()));
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
                if (_actor.GetComponent<VirusA>() == null)
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
        StartCoroutine(StartSick(_disease));
    }

    IEnumerator StartSick(Disease _disease) {
        Debug.Log(_disease.name + "Hey Im Ready To Fuck You");
        sickTime = 0f;
        while (sickTime < _disease.OnSet) {
            sickTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(StartDeath(_disease));
    }

    IEnumerator StartDeath(Disease _disease) {
        timeToDie = 0f;
        while (timeToDie < _disease.TimeUntilDeath) {
            timeToDie += Time.deltaTime;
            yield return null;
        }
        KillActor();
    }

    private void KillActor()
    {
        if (GetComponent<AI>() != null) {
            GetComponent<AI>().enabled = false;
            Debug.Log("Desactivado");
        }
        else if(GetComponent<Player>()!=null){
            GetComponent<Player>().MoveSpeed = 0f;
            Time.timeScale = 0f;
            print("Game Over");
        }
    }
}
