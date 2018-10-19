using UnityEngine;

public class Factory : MonoBehaviour
{
    private static Factory instance;

    public static Factory Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Spawns the given gameObject template at the given position
    /// </summary>
    /// <param name="_template">Template of the gameObject you want to spawn</param>
    /// <param name="_position">Vector3 with the position in where you want to spawn the object</param>
    public void Fabricate(GameObject _template, Vector3 _position)
    {
        Instantiate(_template, _position, Quaternion.identity);
    }

    /// <summary>
    /// Spawns the given gameObject template at the given position with the given disease type
    /// </summary>
    /// <param name="_template">Template of the gameObject you want to spawn</param>
    /// <param name="_position">Vector3 with the position in where you want to spawn the object</param>
    /// <param name="_type">The type of disease that cures the vaccine</param>
    public void Fabricate(GameObject _template, Vector3 _position, DiseaseType _type)
    {
        GameObject result = Instantiate(_template, _position, Quaternion.identity);
        result.GetComponent<Vaccine>().TypeVaccine = _type;
    }
}
