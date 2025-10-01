using System;
using UnityEngine;

public class SixthTrackerScript : MonoBehaviour {

    //This is the last tracker script of second part of 'A' and last tracker which is sets the first complete part of 'A' active.

    private TrackerPoints trackerPoints;

    private bool isSecondLastTrackersTouched = false;
    public static SixthTrackerScript Instance { get; private set; }

    public event EventHandler onSixthTrackerTouched;

    private TracerSound tracerSound;
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        tracerSound = TracerSound.Instance.GetComponent<TracerSound>();
        trackerPoints = TrackerPoints.Instance.GetComponent<TrackerPoints>();
        trackerPoints.onFinalTrackersTouched += TrackerPoints_onFinalTrackersTouched;
    }

    private void TrackerPoints_onFinalTrackersTouched(object sender, EventArgs e) {
        isSecondLastTrackersTouched = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (Input.GetMouseButton(0) && isSecondLastTrackersTouched) {
            tracerSound.StarPopSound();
            onSixthTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }


}