using System;
using UnityEngine;

public class SeventhTrackerScript : MonoBehaviour {

    public static SeventhTrackerScript Instance { get; private set; }

    public event EventHandler onSeventhTrackerTouched;

    private SixthTrackerScript sixthTrackerScript;
    private bool isSixthTrackerTouched = false;

    private void Awake() {
        Instance = this;
    }

    private void Start () {
        sixthTrackerScript = SixthTrackerScript.Instance.GetComponent<SixthTrackerScript>();
        sixthTrackerScript.onSixthTrackerTouched += SixthTrackerScript_onSixthTrackerTouched;
    }

    private void SixthTrackerScript_onSixthTrackerTouched(object sender, System.EventArgs e) {
        isSixthTrackerTouched = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (Input.GetMouseButton(0) && isSixthTrackerTouched) {
            onSeventhTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }
}
