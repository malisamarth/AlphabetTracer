using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoBackToMenuScript : MonoBehaviour {

    //This script is used in "Info" scene to handle the moving between game scenes.

    //Loads the menu scene back.
    public void BacKToMenu() {
        SceneManager.LoadScene(0);
    }

    //Loads to the 'A' scene, start of the game.
    public void BackToAScene() {
        SceneManager.LoadScene(1);
    }

}
