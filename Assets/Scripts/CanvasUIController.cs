using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasUIController : MonoBehaviour
{
    private string MAIN_MENU = "MainMenu";
    private string GAMEPLAY = "Gameplay";
    public void RestartGame() {
        SceneManager.LoadScene(GAMEPLAY);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene(MAIN_MENU);
    }
}
