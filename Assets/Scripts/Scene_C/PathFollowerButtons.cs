using UnityEngine;
using UnityEngine.SceneManagement;

public class PathFollowerButtons : MonoBehaviour {

    //This are UI buttons present on the 'C' scene.

    private int sceneC = 2;
    private int sceneA = 1;
    private int menuA = 0;

    public void Redraw() {
        SceneManager.LoadScene(sceneC);
    }

    public void PreviousButton() {
        SceneManager.LoadScene(sceneA);
    }

    public void MenuButton() {
        SceneManager.LoadScene(menuA);
    }

}
