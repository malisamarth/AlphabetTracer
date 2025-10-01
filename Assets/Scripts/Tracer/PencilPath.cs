using UnityEngine;

public class PencilPath : MonoBehaviour {

    //This scripts handles the movement of pencil, its equals to mouse positin on screeen.

    public static PencilPath Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    private void Update() {
        
        Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cameraPosition.z = 0f;

        transform.position = cameraPosition;

    }

}