using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] Collider plane;
    [SerializeField] GameObject vaccineTemplate;
    [SerializeField] int numberOfEachVaccine;
    [SerializeField] GameObject canvasWin;
    [SerializeField] Text textState;

    private void Start()
    {
        Factory.Instance.Fabricate(key, GetRandomPoint());

        for (int i = 0; i < numberOfEachVaccine; i++)
        {
            Factory.Instance.Fabricate(vaccineTemplate, GetRandomPoint(), DiseaseType.VirusA);
            Factory.Instance.Fabricate(vaccineTemplate, GetRandomPoint(), DiseaseType.VirusS);
        }

        Actor.OnGameOver += GameOver;
        Player.OnWin += Win;
    }

    public void PausedGame()
    {
        Time.timeScale = 0.1f;
    }

    public void ResumeGame() {
        Time.timeScale = 1;
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void GameOver()
    {
        canvasWin.SetActive(true);
        textState.text = "LOSER";
        Time.timeScale = 0.1f;
    }

    private void Win()
    {
        canvasWin.SetActive(true);
        textState.text = "WINNER";
        Time.timeScale = 0.1f;
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
