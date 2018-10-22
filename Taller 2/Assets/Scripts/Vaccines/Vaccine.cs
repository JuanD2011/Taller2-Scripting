using UnityEngine;

public class Vaccine : MonoBehaviour
{
    [SerializeField] private DiseaseType typeVaccine;
    public DiseaseType TypeVaccine
    {
        get
        {
            return typeVaccine;
        }

        set
        {
            typeVaccine = value;
        }
    }

    private float immunity;
    public float Immunity
    {
        get
        {
            return Random.Range(0.05f, 0.4f);
        }
    }
}
