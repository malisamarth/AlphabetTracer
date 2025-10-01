using System;
using UnityEngine;

public class SecondTrackerScript : MonoBehaviour {
    public static SecondTrackerScript Instance { get; private set; }

    public event EventHandler onSecondTrackerTouched;

    private void Awake() {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (Input.GetMouseButton(0)) {
            onSecondTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }
}
