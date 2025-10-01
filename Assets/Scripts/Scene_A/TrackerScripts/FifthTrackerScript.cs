using System;
using UnityEngine;

public class FifthTrackerScript : MonoBehaviour {

    public static FifthTrackerScript Instance { get; private set; }

    public event EventHandler onFifthTrackerTouched;

    private void Awake() {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision) { 

        if (Input.GetMouseButton(0)) {
            onFifthTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }

}
