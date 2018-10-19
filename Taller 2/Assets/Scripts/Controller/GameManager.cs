using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] Collider plane;
    [SerializeField] GameObject vaccineTemplate;
    [SerializeField] int numberOfEachVaccine;

    private void Start()
    {
        Instantiate(key, GetRandomPoint(), Quaternion.identity);

        for (int i = 0; i < numberOfEachVaccine; i++)
        {
            Factory.Instance.Fabricate(vaccineTemplate, GetRandomPoint(), DiseaseType.VirusA);
            Factory.Instance.Fabricate(vaccineTemplate, GetRandomPoint(), DiseaseType.VirusS);
        }
    }

    public void PausedGame() {
        Time.timeScale = 0;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }

    public void ExitGame() {
        Application.Quit();
    }

    /// <summary>
    /// Returns a random point in a given area
    /// </summary>
    /// <returns></returns>
    private Vector3 GetRandomPoint()
    {
        Vector3 result = new Vector3();
        result = new Vector3(Random.Range(plane.bounds.min.x,plane.bounds.max.x),0.5f, Random.Range(plane.bounds.min.z, plane.bounds.max.z));
        return result;
    }
}
