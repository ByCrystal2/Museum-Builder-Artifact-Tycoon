using UnityEngine;

public class MeleeController : MonoBehaviour
{
    public Melee CurrentMelee { get; private set; }
     = Melee.None;

    public void ChangeMeleeCombat(Melee melee)
    {
        CloseMelees();
        if (melee == Melee.None) return;
        ActivateDesiredMelee(melee);
        CurrentMelee = melee;
    }
    void CloseMelees()
    {
        int length = transform.childCount;
        for (int i = 0; i < length; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        CurrentMelee = Melee.None;
    }
    void ActivateDesiredMelee(Melee melee)
    {
        transform.GetChild((int)melee).gameObject.SetActive(true);
    }
}
public enum Melee
{
    None = -1,
    Axe,
    Pickaxe,
    Sword,
}
