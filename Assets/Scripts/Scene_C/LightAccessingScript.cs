using System;
using UnityEngine;
using UnityEngine.Rendering;

public class LightAccessingScript : MonoBehaviour {

    //This script handles the lights in the background of 'C'. The goal is make it 'on' when all stars are destroyed but logically its triggers when penicl hits the collider.

    //All the gameobjects of off and on lights
    [SerializeField] private GameObject DimLightOne;
    [SerializeField] private GameObject DimLightTwo;
    [SerializeField] private GameObject DimLightThree;
    [SerializeField] private GameObject DimLightFour;

    [SerializeField] private GameObject BrightLightOne;
    [SerializeField] private GameObject BrightLightTwo;
    [SerializeField] private GameObject BrightLightThree;
    [SerializeField] private GameObject BrightLightFour;

    //In the begining lights are off.
    private void Start() {
        DimLights();
    }

    //When penicl touches the collider its turns 'on', and most likely by the time it turn 'on' light. All the stars have destroyed.
    private void OnTriggerEnter2D(Collider2D collision) {
        BrightLights();
    }

    //User defined function to turn 'off' and 'on' lights.
    private void DimLights() {
        DimLightOne.SetActive(true);
        DimLightTwo.SetActive(true);
        DimLightThree.SetActive(true);
        DimLightFour.SetActive(true);
        BrightLightOne.SetActive(false);
        BrightLightTwo.SetActive(false);
        BrightLightThree.SetActive(false);
        BrightLightFour.SetActive(false);
    }

    private void BrightLights() {
        DimLightOne.SetActive(false);
        DimLightTwo.SetActive(false);
        DimLightThree.SetActive(false);
        DimLightFour.SetActive(false);
        BrightLightOne.SetActive(true);
        BrightLightTwo.SetActive(true);
        BrightLightThree.SetActive(true);
        BrightLightFour.SetActive(true);
    }

}
