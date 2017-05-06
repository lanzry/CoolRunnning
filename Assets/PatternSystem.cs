using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatternSystem : MonoBehaviour {
    public List<GameObject> buildingPref = new List<GameObject>();
    public List<GameObject> itemPref = new List<GameObject>();
    public GameObject spawnPref;
    public GameObject floorPref;
    public bool loadingComplete;

    public static PatternSystem instance;
    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
