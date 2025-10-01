using System;
using UnityEngine;

public class StarScript : MonoBehaviour {

    //This script is attached to every prefab of star object and its childern. Goal is to get self destroy when it touches the pencil or triggers it.
    public static StarScript Instance { get; private set; }

    private PathFollowerStar pathFollowerStar; //This is reference to the Star sound script, name is misleading.

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        pathFollowerStar = PathFollowerStar.Instance.GetComponent<PathFollowerStar>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {

        pathFollowerStar.StarPopSound();

        Destroy(gameObject);

    }

}