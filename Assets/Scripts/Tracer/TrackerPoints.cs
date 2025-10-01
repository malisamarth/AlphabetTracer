using System;
using UnityEngine;
using UnityEngine.Rendering;

public class TrackerPoints : MonoBehaviour {

    //This scripts handles the entire logic of scene 'A', scribble which is valid and forms the painted 'A' on screen.

    public static TrackerPoints Instance { get; private set; }

    public event EventHandler onTwoTrackersTouched;
    public event EventHandler onFinalTrackersTouched;

    //This are sprite of painted 'A', in parts.
    [SerializeField] private GameObject CompleteHalfOneSprite;
    [SerializeField] private GameObject CompleteHalfTwoSprite;
    [SerializeField] private GameObject CompleteHalfThreeSprite;

    //This are the guides on each part of 'A', bascailly its tell where it scribble.
    [SerializeField] private GameObject DrawMarkerUpper;
    [SerializeField] private GameObject DrawMarkerLower;
    [SerializeField] private GameObject DrawMarkerMiddle;

    //This is one single unit sprite of 'A' and other is the Backgroud patches to cover the screen and run the animation smoothly.
    //This is the animation which runs after completing the 'A'.
    [SerializeField] private GameObject fullAObjectSprite;
    [SerializeField] private GameObject CoverPatchesSprites;

    //This are the trackers/colliders scripts which are present on the outline of 'A', this are monitored and these are responsible for painting the parts of 'A'.
    private FirstTrackerScript firstTrackerScript;
    private SecondTrackerScript secondTrackerScript;
    private ThirdTrackerScript thirdTrackerScript;
    private FourthTrackerScript fourthTrackerScript;
    private FifthTrackerScript fifthTrackerScript;
    private SixthTrackerScript sixthTrackerScript;
    private SeventhTrackerScript seventhTrackerScript;
    private EightTrackerScript eightTrackerScript;

    private DrawWithMouse drawWithMouse;

    //This keeps track if the scribble is going on the right direction and its valid.
    private bool isFirstTrackerTouced = false;
    private bool isSecondTrackerTouced = false;
    private bool isThirdTrackerTouced = false;
    private bool isFourthTrackerTouced = false;
    private bool isFifthTrackerTouced = false;
    private bool isSixthTrackerTouced = false;
    private bool isSeventhTrackerTouced = false;
    private bool isEightTrackerTouced = false;
    private bool isCompleteHalfOneSpriteActive = false;
    private bool isCompleteHalfTwoSpriteActive = false;


    private void Awake() {
        Instance = this;
    }
    private void Start() {
        //All the tracker scripts reference.
        drawWithMouse = DrawWithMouse.Instance.GetComponent<DrawWithMouse>();
        firstTrackerScript = FirstTrackerScript.Instance.GetComponent<FirstTrackerScript>();
        secondTrackerScript = SecondTrackerScript.Instance.GetComponent<SecondTrackerScript>();
        thirdTrackerScript = ThirdTrackerScript.Instance.GetComponent<ThirdTrackerScript>();
        fourthTrackerScript = FourthTrackerScript.Instance.GetComponent<FourthTrackerScript>();
        fifthTrackerScript = FifthTrackerScript.Instance.GetComponent<FifthTrackerScript>();
        sixthTrackerScript = SixthTrackerScript.Instance.GetComponent<SixthTrackerScript>();
        seventhTrackerScript = SeventhTrackerScript.Instance.GetComponent<SeventhTrackerScript>();
        eightTrackerScript = EightTrackerScript.Instance.GetComponent<EightTrackerScript>();

        //So this are the function which gets called when the colliders has triggered.
        firstTrackerScript.onFirstTrackerTouched += FirstTrackerScript_onFirstTrackerTouched;
        secondTrackerScript.onSecondTrackerTouched += SecondTrackerScript_onSecondTrackerTouched;
        thirdTrackerScript.onThirdTrackerTouched += ThirdTrackerScript_onThirdTrackerTouched;
        fourthTrackerScript.onFourthTrackerTouched += FourthTrackerScript_onFourthTrackerTouched;
        fifthTrackerScript.onFifthTrackerTouched += FifthTrackerScript_onFifthTrackerTouched;
        sixthTrackerScript.onSixthTrackerTouched += SixthTrackerScript_onSixthTrackerTouched;
        seventhTrackerScript.onSeventhTrackerTouched += SeventhTrackerScript_onSeventhTrackerTouched;
        eightTrackerScript.onEightTrackerTouched += EightTrackerScript_onEightTrackerTouched;

        DrawMarkerUpper.SetActive(true); //This set the first part of guide to scribble.
    }

    //This all tracker function and booleans are dependent on each other, its wont gate actiavted or is valid until its predecessor is triggered.
    private void EightTrackerScript_onEightTrackerTouched(object sender, EventArgs e) {
        if (isSeventhTrackerTouced) {
            isEightTrackerTouced = true;
        }
    }

    private void SeventhTrackerScript_onSeventhTrackerTouched(object sender, EventArgs e) {
        if (isSixthTrackerTouced) {
            isSeventhTrackerTouced = true;
        }
    }

    private void SixthTrackerScript_onSixthTrackerTouched(object sender, EventArgs e) {
        if (isCompleteHalfOneSpriteActive && isFifthTrackerTouced && isFourthTrackerTouced) {
            isSixthTrackerTouced = true;
        }
    }

    private void FifthTrackerScript_onFifthTrackerTouched(object sender, EventArgs e) {
        if (isCompleteHalfOneSpriteActive && isFourthTrackerTouced) {
            isFifthTrackerTouced = true;
            onFinalTrackersTouched?.Invoke(this, EventArgs.Empty);
        }
    }

    private void FourthTrackerScript_onFourthTrackerTouched(object sender, EventArgs e) {
        if (isCompleteHalfOneSpriteActive && isThirdTrackerTouced) {
            isFourthTrackerTouced = true;
        }
    }

    private void ThirdTrackerScript_onThirdTrackerTouched(object sender, System.EventArgs e) {
        if (isFirstTrackerTouced && isSecondTrackerTouced) {
            isThirdTrackerTouced = true;
        }
    }

    private void SecondTrackerScript_onSecondTrackerTouched(object sender, System.EventArgs e) { 
        if (isFirstTrackerTouced) {
            isSecondTrackerTouced = true;
            onTwoTrackersTouched?.Invoke(this, new EventArgs());
        }
    }

    private void FirstTrackerScript_onFirstTrackerTouched(object sender, System.EventArgs e) {
        isFirstTrackerTouced = true;
    }


    private void Update() {
        
        //Checks if the first part trackers are triggered and loads the first complete part.
        if (isFirstTrackerTouced && isSecondTrackerTouced && isThirdTrackerTouced) {
            FirstCompletePart();
        }

        //Checks if the second part trackers are triggered and loads the second complete part.
        if (isFourthTrackerTouced && isFifthTrackerTouced && isSixthTrackerTouced && isCompleteHalfOneSpriteActive) {
            SecondCompletePart();
        }

        //Checks if the both part trackers are triggered and loads the final complete part and also triggers the animation object.
        if (isCompleteHalfOneSpriteActive && isCompleteHalfTwoSpriteActive && isSeventhTrackerTouced && isEightTrackerTouced) {
            FullCompleteWhole();
            ActivateCompleteAnimationObject();
        }

    }


    private void FirstCompletePart() {
        CompleteHalfOneSprite.SetActive(true);
        isCompleteHalfOneSpriteActive = true;
        DrawMarkerUpper.SetActive(false);
        DrawMarkerLower.SetActive(true);
    }

    private void SecondCompletePart() {
        CompleteHalfTwoSprite.SetActive(true);
        isCompleteHalfTwoSpriteActive = true;
        DrawMarkerMiddle.SetActive(true);
        DrawMarkerLower.SetActive(false);
    }

    private void FullCompleteWhole() {
        CompleteHalfThreeSprite.SetActive(true);
        DrawMarkerMiddle.SetActive(false);
        drawWithMouse.RemoveLine();

        CompleteHalfOneSprite.SetActive(false);
        CompleteHalfTwoSprite.SetActive(false);
        CompleteHalfThreeSprite.SetActive(false);
    }

    private void ActivateCompleteAnimationObject() {
        CoverPatchesSprites.SetActive(true);
        fullAObjectSprite.SetActive(true);
    }

}