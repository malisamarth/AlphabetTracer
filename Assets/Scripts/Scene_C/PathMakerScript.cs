using UnityEngine;

public class PathMakerScript : MonoBehaviour {

    /*
     * This script is responsible for creating the path of 'C'. So in editor we have PathFollower object which has line renderer component,
     * and thirteen circle sprites which are placed on certain manuallt fixed location, on circular way. The we drag and drop each circle sprite
     * into the Path points field present on the line renderer component. Path point are the points which forms line line connecting the respective locations.
     * 
     * Then inside this script we make that the line renderer by passing the information.
     * 
     * This makes path on which we will move our pencil, which cant be moved other than the its set path or destination.
     * 
     * Although this script doesnt add a viusal element as it gets overpowered by the solid 'C' sprite.
    */


    public Transform[] pathPoints; //All the circle sprites transfom component data.
    private LineRenderer lineRenderer; //Reference to the line renderer component on the parent.

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        //If line renderer is null or the path points array are empty we exist the function, cuz there is nothing to renderer.
        if (lineRenderer == null || pathPoints.Length == 0) {
            return;
        }

        //If there are path point array has points it starts the process of rendering them by setting up the data.
        //Set the position count of line renderer to length of path point array or to number cicle points.
        lineRenderer.positionCount = pathPoints.Length;

        for (int i = 0; i < pathPoints.Length; i++) {

            LineRendererData();

            lineRenderer.SetPosition(i, pathPoints[i].position);
        }
    }

    //Basic Line render data.
    private void LineRendererData() {
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        Color32 grayeshShade = new Color32(30, 42, 71, 255);
        lineRenderer.startColor = grayeshShade;
        lineRenderer.endColor = grayeshShade;
    }


}
