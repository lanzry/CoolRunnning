using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {
    [System.Serializable]
    public class AnimationSet {
        public AnimationClip animation;
        public float speed;
    }

    public AnimationSet dead, jumpDown, jumpLoop, jumpUp, roll, run, turnLeft, turnRight;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
