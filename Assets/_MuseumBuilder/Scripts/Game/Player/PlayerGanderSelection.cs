using UnityEngine;

public class PlayerGanderSelection : MonoBehaviour
{
    Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerSelection();
        PlayerGander currentGander = GameManager.Instance.GetPlayerGender();
        PlayerSelection((int)currentGander);
    }
    void PlayerSelection(int index = -1)
    {
        bool isClear = index <= -1;
        int length = isClear ? player.childCount : index;
        if (isClear)
            for (int i = 0; i < length; i++)
            {
                GameObject currentChild = player.GetChild(i).gameObject;
                if (currentChild.TryGetComponent(out Renderer renderer))
                    renderer.gameObject.SetActive(false);
            }
        else
            player.GetChild(length+1).gameObject.SetActive(true);

    }
}
public enum PlayerGander
{
    Male,
    Female
}
