using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI.Table;

public class DragAlong : MonoBehaviour {

    /*
     * Please read the "PathMakerScript" before reading this one. This build on that one. 
     * 
     * This script is responsible for moving the pencil on the rendrerd path created by path maker script.
     * 
     * Here we calcualte the distance and perpenducular from the mouse to the points and move the pencil.
     * 
     */


    public Transform[] pathPoints; // The transform data of circle sprites which make the points of path.
    private Camera mainCam; // Reference to store main camera field.
    private bool isDragging = false; //Checks if we are dragging.

    private void Start() {
        mainCam = Camera.main; //Assign the camera to to main camera delcaration.
    }

    private void Update() {

        //Start dragging, if the left click held, dragging boolean isnt true its wont start pencil movement.
        if (Input.GetMouseButtonDown(0)) { 
            isDragging = true;
        }
        //Stop dragging, as soon as we leave the left click on mouse it sets the dragging boolean to false. Hence its stop the movement of pencil.
        if (Input.GetMouseButtonUp(0)) {
            isDragging = false;
        }

        //When we are dragging the left click.
        if (isDragging) {
            Vector3 mouseWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorld.z = 0f; // cuz we are in 2d man!!

            //We call the Use defined function, to find the closest point on the path and store its return as vector3 and we pass the current mouse position to it.
            Vector3 closest = GetClosestPointOnPath(mouseWorld);

            //In the end we move the pencile or gameobject to the nearest location to the point, which is returned from the UDF.
            transform.position = closest;
            
        }
    }

    //This function is responsibel for finding the closest position with respect to the mouse screen position.
    //In parameters we take current mouse screen position and its vairbale name is 'target'.
    Vector3 GetClosestPointOnPath(Vector3 target) {
        Vector3 closestPoint = pathPoints[0].position; //Placeholder for just to get started. Value changes
        float closestDist = float.MaxValue; //Placeholder for just to get started.

        //This loop goals is to check all position in the path points array to find which is closer to the mouse position.
        for (int i = 0; i < pathPoints.Length - 1; i++) {

            Vector3 positionOne = pathPoints[i].position; //We take the first position.
            Vector3 positionTwo = pathPoints[i + 1].position; //We take immedeidate next position after the positionOne.

            //We again call the next User defined function to check where the point falls on the line or two points.
            Vector3 projected = ProjectPointOnLineSegment(positionOne, positionTwo, target);
            float dist = Vector3.Distance(target, projected);

            if (dist < closestDist) {
                closestDist = dist;
                closestPoint = projected;
            }
        }

        return closestPoint;
    }

    /* This function does the maths of finding the a point on a line segment which has two points A and B. And we calcuate the Dot product.
     * We use projection formula.
     * It forms perpendicular to get the point on line.
     * The parameters are two vectors position PositionA and PositionB, and current mouse position on screen which is target.
     * It returns the position vector of closet point.
     */
    Vector3 ProjectPointOnLineSegment(Vector3 positionA, Vector3 positionB, Vector3 targetPoint) {

        //We calculate the distance from A to P and A to B.
        Vector3 positionFromAtoP = targetPoint - positionA;
        Vector3 positionFromAtoB = positionB - positionA;

        //Using squared length avoids the slow square root calculation, and we don’t need the actual length, just the squared version for ratio.
        //We square the length because we will divide by it later in projection formula.
        float magnitudeAB = positionFromAtoB.sqrMagnitude;

        //Dot product measures how much AP points in the same direction as AB. A number (can be positive, zero, or negative)
        float abAPproduct = Vector3.Dot(positionFromAtoP, positionFromAtoB);

        /*
         * Divide dot product by length squared, fraction along the line.
         * 
         * distance = 0 = exactly at A
         * distance = 1 = exactly at B
         * 0 < distance < 1 = somewhere between A and B
         * distance < 0 = before A
         * distance > 1 = beyond B
         * 
         */
        float distance = abAPproduct / magnitudeAB;

        if (distance < 0) {
            return positionA;
        } else if (distance > 1) {
            return positionB;
        } else {
            return positionA + positionFromAtoB * distance;
        }
        
    }

}
