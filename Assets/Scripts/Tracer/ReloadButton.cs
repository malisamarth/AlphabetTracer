using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour {

    //Reloads the scene
    public void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
