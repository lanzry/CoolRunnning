using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSpawnCheck : MonoBehaviour {

    public bool isCollision = false;
    public GameObject headParent;
    public string nameColliderHit;
    public bool checkByName;
    public bool checkByTag;
    public float nextPos;

    private GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player");
        } else {
            if(player.transform.position.z >= this.transform.position.z) {
                isCollision = true;
            }
        }
	}
}
