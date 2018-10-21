using UnityEngine;

public class Key : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>()!=null) {
            other.GetComponent<Player>().Key = true;
            Destroy(gameObject);
        }
    }
}
