using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float speedAddEveryDistance;
    public float speedAdd;
    public float Max;
    public float distanceCheck;
    public float countAndSpeed;
    public GameObject playerPref;
    public Vector3 posStart;
    public PatternSystem patternSystem;
    public CameraFollow cameraFollow;

    public static GameController instance;
	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator ResetGame() {
        GameAttribute.gameAttribute.isPlaying = false;
        distanceCheck = 0;
        countAndSpeed = 0;
        yield return 0;
    }
}
