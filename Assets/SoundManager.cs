using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    [System.Serializable]
    public class Sound {
        public AudioClip audioClip;
        public string soundName;
    }
    public AudioSource bgm;
    public List<Sound> soundList = new List<Sound>();
    public static SoundManager instance;
	// Use this for initialization
	void Start () {
        instance = this;
        StartCoroutine(PlayBGM());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayingSound(string soundName) {
        AudioSource.PlayClipAtPoint(soundList[IndexOfSound(soundName)].audioClip, Camera.main.transform.position);
    }

    int IndexOfSound(string soundName) {
        int i = 0;
        int count = soundList.Count;
        while(i < count) {
            if (soundList[i].soundName.Equals(soundName))
                return i;
            i++;
        }
        return i;
    }

    void DoPlayBGM() {
        StartCoroutine(PlayBGM());
    }

    IEnumerator PlayBGM() {
        yield return new WaitForSeconds(0.5f);
        while (!PatternSystem.instance.loadingComplete) {
            yield return 0;
        }

        bgm.Play();
    }
}
