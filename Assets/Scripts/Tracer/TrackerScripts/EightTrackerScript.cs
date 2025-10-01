using System;
using UnityEngine;

public class EightTrackerScript : MonoBehaviour {

    //This is the last tracker script of final part of 'A' and last tracker which is sets the first complete 'A' active.
    public static EightTrackerScript Instance {get; private set; }
    private TracerSound tracerSound;
    public event EventHandler onEightTrackerTouched;
    private SeventhTrackerScript seventhTrackerScript;
    private bool isSeventhTrackerTouched = false;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        tracerSound = TracerSound.Instance.GetComponent<TracerSound>();
        seventhTrackerScript = SeventhTrackerScript.Instance.GetComponent<SeventhTrackerScript>();
        seventhTrackerScript.onSeventhTrackerTouched += SeventhTrackerScript_onSeventhTrackerTouched;
    }

    private void SeventhTrackerScript_onSeventhTrackerTouched(object sender, System.EventArgs e) {
        isSeventhTrackerTouched = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (Input.GetMouseButton(0) && isSeventhTrackerTouched) {
            tracerSound.StarPopSound();
            onEightTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);
        }


    }
}
