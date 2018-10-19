using UnityEngine;

public class Vaccine : MonoBehaviour
{
    private DiseaseType typeVaccine;
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
            return immunity;
        }

        set
        {
            immunity = value;
        }
    }


}
