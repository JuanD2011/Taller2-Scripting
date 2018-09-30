using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;

    [SerializeField] float smoothSpeed;
    Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0, 10, 0);
        target = PlayerManager.Instance.player.transform;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(desiredPosition.x, desiredPosition.y, desiredPosition.z), smoothSpeed);
        transform.position = smoothedPosition;
    }
}
