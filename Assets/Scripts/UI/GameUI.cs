using UnityEngine;

public class GameUI : MonoBehaviour
{
    // Called by UI button press
    public void OnStartGame() => EventManager.StartGame();
}