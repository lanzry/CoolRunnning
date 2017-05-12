using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public float scoreAdd;                  // 增加的分数，item == coin
    public float dcreaseLife;
    public float itemId;
    public float duration;
    public float itemEffectValue;
    public ItemRotate itemRotate;
    public GameObject effectHit;
    public ItemType itemType;

    [HideInInspector]
    public bool useAbsorb = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GetItem() {
        if (!GameAttribute.gameAttribute.delayDetect) {
            switch (itemType) {
                case ItemType.COIN:
                    HitCoin();
                    SoundManager.instance.PlayingSound("GetCoin");
                    break;
                case ItemType.OBSTACLE:
                    HitObstacle();
                    SoundManager.instance.PlayingSound("HitOBJ");
                    break;
                case ItemType.OBSTACLE_ROLL:
                    if (!Controller.instance.isRoll) {
                        HitObstacle();
                        SoundManager.instance.PlayingSound("HitOBJ");
                    }
                    break;
                case ItemType.ITEM_SPRINT:

                    break;
            }
        }
    }

    // 碰撞金币
    private void HitCoin() {
        if (Controller.instance.isCoinMultiply)
            GameAttribute.gameAttribute.coin += GameAttribute.gameAttribute.coinMultiplyValue * scoreAdd;
        else
            GameAttribute.gameAttribute.coin += scoreAdd;
    }

    // 碰撞障碍物
    private void HitObstacle() {
        if (Controller.instance.timeSprint < 0) {
            GameAttribute.gameAttribute.life -= 1;
            CameraFollow.instance.ShakeCamrea();
        } else {
            HideItem();
            CameraFollow.instance.ShakeCamrea();
        }
    }

    // 隐藏该对象
    private void HideItem() {
        if (!useAbsorb) {
            this.transform.parent = null;
            this.transform.position = new Vector3(-100, -100, -100);
        }
    }
}
