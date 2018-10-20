﻿using UnityEngine;
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
    protected bool isSick = false;

    public delegate void DelActor();

    protected virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();

        if (GetComponent<Disease>() != null)
        {
            isSick = true;
            disease = GetComponent<Disease>();
            StartCoroutine(StartSick(disease));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Actor>() != null) {
            if (disease != null) {
                //disease = GetComponent<Disease>();
                SetDisease(disease, collision.gameObject.GetComponent<Actor>());
            }
        }
    }

    private void SetDisease(Disease _disease, Actor _actor) {
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
        if(_actor.GetComponent<Disease>()!=null)
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
        isSick = true;
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
            GetComponent<AI>().enabled = false;
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
