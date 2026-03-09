using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public static bool isDay = true; // Start with day

    void Lose()
    {
        // Handle game over logic here (e.g.show game over screen, restart game, etc.)
    }
    void RestartGame()
    {
        // Handle game restart logic here (e.g., reset player position, reset score, etc.)
    }
    void PauseGame()
    {
        // Handle game pause logic here (e.g., pause game, show pause screen, etc.)
    }
}
