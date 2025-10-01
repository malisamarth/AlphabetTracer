using System;
using UnityEngine;

public class PathFollowerStar : MonoBehaviour {

    //This script has star pop/destroy sound effect. Its name is misleading.
    public static PathFollowerStar Instance { get; private set; }

    [SerializeField] private AudioClip starPopSound;

    private void Awake() {
        Instance = this;
    }

    //Public function so it can be accessed from anywhere in the project.
    public void StarPopSound() {
        AudioSource.PlayClipAtPoint(starPopSound, Camera.main.transform.position);
    }

}