using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroudMusicLoop : MonoBehaviour {

    //This script handles the backgroud playful music which playing constantly.

    [SerializeField] private AudioClip backgroundMusic;

    private AudioSource audioSource;

    private static BackgroudMusicLoop Instance;

    private void Awake() {


        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        //This makes sure that this object doesnt get destroyed when we change the scenes, so it is playing thoughout the game.
        Instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        //Basically it changes the few attribute of the music depending on the scene.
        SceneTransitionBackgroundMusic(SceneManager.GetActiveScene());
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnDestroy() {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene oldScene, Scene newScene) {
        //Calls the UDF to change the volume depending on the current active scene.
        SceneTransitionBackgroundMusic(newScene);
    }

    private void SceneTransitionBackgroundMusic(Scene currentScene) {
        if (currentScene.buildIndex == 0) {
            SetVolume(0.6f);
            PlayMusic();
            

        } else if (currentScene.buildIndex == 1) {
            SetVolume(0.4f); 
            PlayMusic();

        } else if (currentScene.buildIndex == 2) {
            SetVolume(0.4f);
            PlayMusic();
        }

        
    }

    public void PlayMusic() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
        }
    }

    //It sets the volume of audio source.
    //Math.Clamp01 = Set both a minimum and maximum limit to the value you input.
    public void SetVolume(float volume) {
        audioSource.volume = Mathf.Clamp01(volume);
    }


}
