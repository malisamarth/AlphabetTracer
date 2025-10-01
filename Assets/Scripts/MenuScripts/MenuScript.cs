using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    //Starts the game by loading scene one which is 'A' screeen.
    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    //Loads the Info screen where there is explanation of hurdles player might face.
    public void InfoButon() {
        SceneManager.LoadScene(3);
    }

    //Redirects to the Repo.
    public void GitHubDirect() {
        Application.OpenURL("https://github.com/malisamarth/AlphabetTracer");
    }

    //Closes the game.
    public void Exit() {
        Application.Quit();
    }

}
