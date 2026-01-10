using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    [SerializeField] TMP_Dropdown genderSelectionDD;
    [SerializeField] Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
    }
    public void StartGame()
    {
        GameManager.Instance.SetPlayerGander((PlayerGander)genderSelectionDD.value);

        SceneManager.LoadScene("Loading");
    }
}
