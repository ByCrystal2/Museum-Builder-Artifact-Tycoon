using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    PlayerGander _playerGander;

    private void Start()
    {
        Init();
    }
    void Init()
    {
        // Initialization procedures...
        SceneManager.LoadScene("Menu");
    }
    public void SetPlayerGander(PlayerGander playerGander) => _playerGander = playerGander;
    public PlayerGander GetPlayerGender() => _playerGander;

}
