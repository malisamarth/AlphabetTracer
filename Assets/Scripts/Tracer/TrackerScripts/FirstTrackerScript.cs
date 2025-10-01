using System;
using UnityEngine;

public class FirstTrackerScript : MonoBehaviour {

    //There are Eight (8) trackers script, all do the same thing, except few. There is defneitly a better logic than this.

    public static FirstTrackerScript Instance { get; private set; }

    //Creates a public event and invokes it when the triggers takes place.
    public event EventHandler onFirstTrackerTouched; 

    private void Awake() {
        Instance = this;
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        //As the pencil always follows the mouse, this checks if left click is been hold and its in triggering zone.
        if (Input.GetMouseButton(0)) {
            onFirstTrackerTouched?.Invoke(this, EventArgs.Empty);
            Destroy(this.gameObject);

        }


    }

}
