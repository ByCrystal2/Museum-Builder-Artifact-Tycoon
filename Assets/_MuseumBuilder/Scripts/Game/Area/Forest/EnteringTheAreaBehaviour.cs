using UnityEngine;

public class EnteringTheAreaBehaviour : MonoBehaviour
{
    [SerializeField] Melee targetMelee;
    bool isPlayerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMotor playerMotor = other.GetComponent<PlayerMotor>();
            if (playerMotor != null)
            {
                if (!isPlayerInside)
                    playerMotor.meleeController.ChangeMeleeCombat(targetMelee);
                else
                    playerMotor.meleeController.ChangeMeleeCombat(Melee.None);

                isPlayerInside = !isPlayerInside;
            }
            else
                Debug.LogError("The PlayerMotor component must be present in the player!");
        }
    }
}
