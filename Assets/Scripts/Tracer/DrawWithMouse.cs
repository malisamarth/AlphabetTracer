using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {

    public static DrawWithMouse Instance { get; private set; } 

    [SerializeField] private GameObject linePrefab; //Prefab with a LineRenderer
    private LineRenderer currentLineRenderer;
    private List<GameObject> spawnedDrawlines = new List<GameObject>(); //This is array which stores each scribbles. We empty it after entire outline has been painted.

    private float minimuimDistance = 0f; //This the minimum distance between line rendering points.
    private Vector3 previousPosition; //Stores the position which was clicked or hold before moving to next point.

    private PencilPath pencilPath;
    private bool isOnRightPath = true; //This bool keeps tracks if its on outline or outside.

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        pencilPath = PencilPath.Instance.GetComponent<PencilPath>();
    }

    private void Update() {

        //When mouse is pressed, we create a new line renderer
        if (Input.GetMouseButtonDown(0) && isOnRightPath) {
            GameObject newLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity); //We create a prefab child as soon as there is click on valid area.
            spawnedDrawlines.Add(newLine); //Addes the prefab to array.
            currentLineRenderer = newLine.GetComponent<LineRenderer>(); 

            //Set the line renderer to of new scribble.
            currentLineRenderer.positionCount = 0; //It starts from very begining, means the start of line.
            currentLineRenderer.startWidth = 0.9f; //Line width
            currentLineRenderer.endWidth = 0.9f; //Line width
            currentLineRenderer.material = new Material(Shader.Find("Sprites/Default")); //The material is basically set to nothing, its just a solid color.
            Color32 purple = new Color32(90, 62, 135, 255); //Custom color.
            currentLineRenderer.startColor = purple;
            currentLineRenderer.endColor = purple;

            previousPosition = transform.position; //stores the position of gameobject in previous field.
        }

        //While holding mouse. we keep adding points to this new line.
        //Click should be holded, line renderer should be active and the scribbling should be on valid area.
        if (Input.GetMouseButton(0) && currentLineRenderer != null && isOnRightPath) { 
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //We change position as the mouse moves.
            currentPosition.z = 0f; //We are in 2d blud.

            //Basically we calculate the distance between the new points and previous points tand check if its greater than minimuim distance to scribble.
            if (Vector3.Distance(currentPosition, previousPosition) > minimuimDistance) { 
                if (previousPosition == transform.position || currentLineRenderer.positionCount == 0) {
                    currentLineRenderer.positionCount = 1;
                    currentLineRenderer.SetPosition(0, currentPosition);
                } else {
                    currentLineRenderer.positionCount++;
                    currentLineRenderer.SetPosition(currentLineRenderer.positionCount - 1, currentPosition);
                }

                previousPosition = currentPosition;
            }
        }
    } 

    //Removes all the scribble from screeen.
    public void RemoveLine() {

        for ( int index = 0; index < spawnedDrawlines.Count; index++ ) {
            Destroy( spawnedDrawlines[index] );
        }

        spawnedDrawlines.Clear();
        //Debug.Log("Line removed");
    }

    //Activates pencil to scrible if its on valid area.
    public void ActivateDraw() {
        isOnRightPath = true;
    }

    //Deactivates pencil to scrible if its on invalid area.
    public void DeactivateDraw() {
        isOnRightPath = false;
    }
}
