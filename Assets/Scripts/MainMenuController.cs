using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private string GAMEPLAY = "Gameplay";
    public void PlayGameOnButtonClick() {
        int clickedPlayerIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.CharIndex = clickedPlayerIndex;
        SceneManager.LoadScene(GAMEPLAY);
    }
}
