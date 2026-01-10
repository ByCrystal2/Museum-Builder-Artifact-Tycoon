using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    [Header("Offset")]
    public Vector3 offset = new Vector3(0f, 6f, -8f);

    [Header("Smoothness")]
    public float followSpeed = 10f;
    public float rotateSpeed = 8f;

    void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        Quaternion targetRot = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
    }
}
