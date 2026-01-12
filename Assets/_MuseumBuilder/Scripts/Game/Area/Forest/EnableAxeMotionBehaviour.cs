using UnityEngine;

public class EnableAxeMotionBehaviour : MonoBehaviour
{
    private bool hasHit = false;
    Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        hasHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        if (other.CompareTag("Tree"))
        {
            hasHit = true;
            Debug.Log("TREE HIT");
        }
    }

    public void EnableHitbox()
    {
        col.enabled = true;
    }

    public void DisableHitbox()
    {
        col.enabled = false;
        hasHit = false;
    }
}
