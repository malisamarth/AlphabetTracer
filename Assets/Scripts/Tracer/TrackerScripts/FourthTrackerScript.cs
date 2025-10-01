using System;
using UnityEngine;

public class FourthTrackerScript : MonoBehaviour {

    public static FourthTrackerScript Instance { get; private set; }

    public event EventHandler onFourthTrackerTouched;

    private void Awake() {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (Input.GetMouseButton(0)) {
            onFourthTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }

}
