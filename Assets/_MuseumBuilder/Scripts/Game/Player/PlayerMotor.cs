using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public EnableAxeMotionBehaviour motionBehaviour;
    public MeleeController meleeController;
    Animator _animator;
    public float interactRange = 0.2f;
    private void Awake()
    {
        meleeController.ChangeMeleeCombat(Melee.None);
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 origin = transform.position + Vector3.up * 1.2f; // karakter ortasý
        Vector3 direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, 0.5f, direction, out hit, interactRange))
        {
            if (hit.transform.CompareTag("Tree"))
            {
                _animator.SetTrigger("AxeSwing");
            }
        }
    }
    public void EnableAxeMotion()
    {
        motionBehaviour.EnableHitbox();
    }
    public void DisableAxeMotion()
    {
        motionBehaviour.DisableHitbox();
    }


}
