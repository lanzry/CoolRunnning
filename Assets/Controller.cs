using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AnimationManager))]
public class Controller : MonoBehaviour {
    public enum Position {
        LEFT, MIDDLE, RIGHT
    }
    public enum DirectionInput {
        NULL, LEFT, RIGHT, UP, DOWN
    }

    public GameObject coinRotate;
    public GameObject magnet;

    public float speedMove;
    public float gravity;
    public float jumpValue;

    public bool keyInput;
    public bool touchInput;

    [HideInInspector]
    public bool isRoll;
    [HideInInspector]
    public bool isDoubleJump;
    [HideInInspector]
    public CharacterController characterController;

    private AnimationManager animationManager;
    private bool jumpSecond;
    private DirectionInput directionInput;
    private Position positionStand;
    private bool activeInput;

    public static Controller instance;
	// Use this for initialization
	void Start () {
        instance = this;
        characterController = GetComponent<CharacterController>();
        animationManager = GetComponent<AnimationManager>();
        speedMove = GameAttribute.gameAttribute.speed;
        jumpSecond = false;
        magnet.SetActive(false);
        Invoke("WaitStart", 0.2f);
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void WaitStart() {
        StartCoroutine(UpdateAction());
    }

    private IEnumerator UpdateAction() {
        while (GameAttribute.gameAttribute.life > 0) {
            if (GameAttribute.gameAttribute.isPause && GameAttribute.gameAttribute.isPlaying && PatternSystem.instance.loadingComplete) {
                if (keyInput)
                    KeyInput();

                if (touchInput)
                    DirectionAngleInput();


            }
        }

        yield return 0;
    }

    private void CheckLane() {
        switch (positionStand) {
            case Position.MIDDLE:
                if(directionInput == DirectionInput.RIGHT) {
                    if (characterController.isGrounded) {
                        GetComponent<Animation>().Stop();
                        animationManager.animationState = animationManager.TurnRight;
                    }
                    positionStand = Position.RIGHT;
                    SoundManager.instance.PlayingSound("Step");
                }else if (directionInput == DirectionInput.LEFT) {
                    if (characterController.isGrounded) {
                        GetComponent<Animation>().Stop();
                        animationManager.animationState = animationManager.TurnLeft;
                    }
                    positionStand = Position.LEFT;
                    SoundManager.instance.PlayingSound("Step");
                }
                break;
        }
    }

    private void KeyInput() {
        if (Input.anyKeyDown)
            activeInput = true;

        if (activeInput) {
            switch (Event.current.keyCode) {
                case KeyCode.A:
                    directionInput = DirectionInput.LEFT;
                    break;
                case KeyCode.W:
                    directionInput = DirectionInput.UP;
                    break;
                case KeyCode.S:
                    directionInput = DirectionInput.DOWN;
                    break;
                case KeyCode.D:
                    directionInput = DirectionInput.RIGHT;
                    break;
            }
            activeInput = false;
        } else {
            directionInput = DirectionInput.NULL;
        }
    }

    private Vector2 currentP;
    private void TouchInput() {
        if (Input.GetMouseButtonDown(0)) {
            currentP = Input.mousePosition;
            activeInput = true;
        }
        if (Input.GetMouseButton(0)) {
            if (activeInput) {
                if((Input.mousePosition.x-currentP.x) > 40) {
                    directionInput = DirectionInput.RIGHT;
                }else if ((Input.mousePosition.x - currentP.x) < -40) {
                    directionInput = DirectionInput.LEFT;
                }else if ((Input.mousePosition.y - currentP.y) > 40) {
                    directionInput = DirectionInput.UP;
                }else if ((Input.mousePosition.y - currentP.y) < -40) {
                    directionInput = DirectionInput.DOWN;
                }
                activeInput = false;
            } else {
                directionInput = DirectionInput.NULL;
            }
            if (Input.GetMouseButtonUp(0)) {
                directionInput = DirectionInput.NULL;
            }
            currentP = Input.mousePosition;
        }
    }

    private void DirectionAngleInput() {
        if (Input.GetMouseButtonDown(0)) {
            currentP = Input.mousePosition;
            activeInput = true;
        }
        if (Input.GetMouseButton(0)) {
            if (activeInput) {
                float disX = Input.mousePosition.x - currentP.x;
                float disY = Input.mousePosition.y - currentP.y;
                // x轴y轴 有一方向移动距离超过20就触发
                if(Mathf.Abs(disX) > 20 || Mathf.Abs(disY) > 20) {
                    // 触发时，y轴移动较多
                    if (Mathf.Abs(disY) >= Mathf.Abs(disX)) {
                        if (disY > 0)
                            directionInput = DirectionInput.UP;
                        else
                            directionInput = DirectionInput.DOWN;
                    } else {
                        // 触发时，x轴移动较多
                        if (disX > 0)
                            directionInput = DirectionInput.RIGHT;
                        else
                            directionInput = DirectionInput.LEFT;
                    }
                    activeInput = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            directionInput = DirectionInput.NULL;
            activeInput = false;
        }
    }
}
