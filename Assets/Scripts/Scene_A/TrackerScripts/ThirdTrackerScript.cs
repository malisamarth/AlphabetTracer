using System;
using UnityEngine;

public class ThirdTrackerScript : MonoBehaviour {

    //This is the last tracker script of the first part of 'A' and last tracker which is sets the first complete part of 'A' active.
    public static ThirdTrackerScript Instance { get; private set; }

    public event EventHandler onThirdTrackerTouched;

    private TrackerPoints trackerPoints;
    private TracerSound tracerSound; //The sound script reference to play the start pop sound when star object is destroyed.

    private bool isTwoTrackersTouched = false; //Checks previous trackers have been triggered.

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        tracerSound = TracerSound.Instance.GetComponent<TracerSound>();
        trackerPoints = TrackerPoints.Instance.GetComponent<TrackerPoints>();
        trackerPoints.onTwoTrackersTouched += TrackerPoints_onTwoTrackersTouched;
    }

    private void TrackerPoints_onTwoTrackersTouched(object sender, EventArgs e) {
        isTwoTrackersTouched = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (Input.GetMouseButton(0) && isTwoTrackersTouched) {
            tracerSound.StarPopSound();
            onThirdTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }

}