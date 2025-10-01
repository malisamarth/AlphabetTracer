using UnityEngine;

public class ValidPath : MonoBehaviour {

    //If the pencil is on valid path is calls the Activate Draw function.

    private DrawWithMouse drawWithMouse;


    private void Start() {
        drawWithMouse = DrawWithMouse.Instance.GetComponent<DrawWithMouse>();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        drawWithMouse.ActivateDraw();
        //Debug.Log("Draw");
    } 


}