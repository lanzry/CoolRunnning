using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{

    private float fadeSpeed = 2f;
    private float allTime;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        allTime += fadeSpeed * Time.deltaTime;
        GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f, Mathf.Sin(allTime)*0.5f);
    }
}
