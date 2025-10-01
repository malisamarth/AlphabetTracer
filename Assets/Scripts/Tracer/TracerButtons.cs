using UnityEngine;
using UnityEngine.SceneManagement;

public class TracerButtons : MonoBehaviour {

    //It internally loads the 'A' scene in the name of redraw!!

    private int sceneA = 1;
    private int sceneC = 2;
    private int sceneMenu = 0;
    private int sceneInfo = 3;

    public void Redraw(){
        SceneManager.LoadScene(sceneA);
    }

    //It loads the next 'C' scene.
    public void Nextbutton() {
        SceneManager.LoadScene(sceneC);
    }

    //Loads the menu scene.
    public void MenuButton() {
        SceneManager.LoadScene(sceneMenu);
    }

    //Loads the info scene.
    public void InfoButon() {
        SceneManager.LoadScene(sceneInfo);
    }

}
