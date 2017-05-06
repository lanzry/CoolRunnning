using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
    [HideInInspector]
    public bool buildingActive;
    [HideInInspector]
    public int buildIndex;

    public static Building instance;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        buildingActive = false;
        this.transform.parent = null;
	}
}
