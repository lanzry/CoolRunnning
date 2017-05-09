using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatternSystem : MonoBehaviour {
    public List<GameObject> buildingPref = new List<GameObject>();
    public List<GameObject> itemPref = new List<GameObject>();
    public GameObject spawnPref;
    public GameObject floorPref;
    public bool loadingComplete;

    // 三个奔跑槽内放置的item类型数组
    [System.Serializable]
    public class ItemTypeSet {
        public int[] leftItemType = new int[31];
        public int[] middleItemType = new int[31];
        public int[] rightItemType = new int[31];
    }
    [HideInInspector]
    public List<ItemTypeSet> patternList = new List<ItemTypeSet>();

    public static PatternSystem instance;
    // Use this for initialization
    void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator calItemAmount() {
        yield return 0;
    }
}
