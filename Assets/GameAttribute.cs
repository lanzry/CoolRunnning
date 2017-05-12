using UnityEngine;
using System.Collections;

public class GameAttribute : MonoBehaviour {

    public float starterSpeed;
    public float starterLife;
    public float speed;

    [HideInInspector]
    public float distance;
    [HideInInspector]
    public float life;
    [HideInInspector]
    public float coin;
    [HideInInspector]
    public float level;
    [HideInInspector]
    public bool isPause;
    [HideInInspector]
    public bool isPlaying;

    [HideInInspector]
    public bool delayDetect;        //延迟检测
    [HideInInspector]
    public float coinMultiplyValue;     // 金币倍数

    public static GameAttribute gameAttribute;

	// Use this for initialization
	void Start () {
        gameAttribute = this;
        // 加载新场景时不销毁
        DontDestroyOnLoad(this);
        StartCoroutine(initAttribute());
    }
	
	void Reset () {
        StartCoroutine(initAttribute());
	}

    // 初始化/重置游戏参数
    private IEnumerator initAttribute() {
        speed = starterSpeed;
        distance = 0;
        life = starterLife;
        level = 0;
        isPause = false;
        isPlaying = true;
        yield return 0;
    }

    public void countDistance(float amount) {
        distance += amount * Time.smoothDeltaTime;
    }
}
