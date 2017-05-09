using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour {
    [System.Serializable]
    public class AnimationSet {
        public AnimationClip animation;
        public float speed = 1;
    }
    public AnimationSet dead, jumpDown, jumpLoop, jumpUp, roll, run, turnLeft, turnRight;

    private Controller controller;
    private float speedRun;
    private float defaultSpeedRun;

    // 方法引用，指向一个方法（将持有该方法的引用，以及该方法的所持有类的对象的引用）
    public delegate void AnimationHandle();     // 定义方法引用
    public AnimationHandle animationState;      // 声明方法引用

    // Use this for initialization
    void Start () {
        controller = this.GetComponent<Controller>();
        defaultSpeedRun = GameAttribute.gameAttribute.speed;
        animationState = Run;
	}
	
	// Update is called once per frame
	void Update () {
        if (animationState != null)
            animationState();
	}

    public void Run() {
        GetComponent<Animation>().Play(run.animation.name);
        speedRun = (GameAttribute.gameAttribute.speed / defaultSpeedRun) * (run.speed);
        GetComponent<Animation>()[run.animation.name].speed = speedRun;
    }

    public void Jump() {
        GetComponent<Animation>().Play(jumpUp.animation.name);
        if(GetComponent<Animation>()[jumpUp.animation.name].normalizedTime > 0.95f) {
            animationState = JumpLoop;
        }
    }

    public void JumpLoop() {
        GetComponent<Animation>().CrossFade(jumpLoop.animation.name);
        if (GetComponent<CharacterController>().isGrounded) {
            animationState = Run;
        }
    }

    public void TurnLeft() {
        GetComponent<Animation>().Play(turnLeft.animation.name);
        GetComponent<Animation>()[turnLeft.animation.name].speed = turnLeft.speed;
        if (GetComponent<Animation>()[turnLeft.animation.name].normalizedTime > 0.95f) {
            animationState = Run;
        }
    }

    public void TurnRight() {
        GetComponent<Animation>().Play(turnRight.animation.name);
        GetComponent<Animation>()[turnRight.animation.name].speed = turnRight.speed;
        if (GetComponent<Animation>()[turnRight.animation.name].normalizedTime > 0.95f) {
            animationState = Run;
        }
    }

    public void Roll() {
        GetComponent<Animation>().Play(roll.animation.name);
        if(GetComponent<Animation>()[roll.animation.name].normalizedTime > 0.95) {
            controller.isRoll = false;
            animationState = Run;
        } else {
            controller.isRoll = true;
        }
    }

    public void Dead() {
        GetComponent<Animation>().Play(dead.animation.name);
    }

    public void JumpSecond() {
        GetComponent<Animation>().Play(roll.animation.name);
        if (GetComponent<Animation>()[roll.animation.name].normalizedTime > 0.95f) {
            animationState = JumpLoop;
        }
    }
}
