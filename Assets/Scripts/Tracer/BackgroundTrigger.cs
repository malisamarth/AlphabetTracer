using UnityEngine;

public class BackgroundTrigger : MonoBehaviour
{
    //This script handles if player accidently or intensionly scribbles outside the outline of Alphabet.

    private DrawWithMouse drawWithMouse; //Reference to call the function which deactivates the scribble.

    private void Start() {
        drawWithMouse = DrawWithMouse.Instance.GetComponent<DrawWithMouse>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        drawWithMouse.DeactivateDraw();
    }
}
