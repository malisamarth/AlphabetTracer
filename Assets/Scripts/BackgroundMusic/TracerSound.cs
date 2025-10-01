using UnityEngine;

public class TracerSound : MonoBehaviour {

    //This is script which handles the sound effect on the 'A' scene.

    public static TracerSound Instance { get; private set; }

    [SerializeField] private AudioClip starPopSound;

    private void Awake() {
        Instance = this;
    }


    public void StarPopSound() {
        AudioSource.PlayClipAtPoint(starPopSound, Camera.main.transform.position);
    }

}
