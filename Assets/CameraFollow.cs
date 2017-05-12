using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float angle;
    public float distance;
    public float height;
    [HideInInspector]
    public Transform target;

    private Vector3 positionV;
    private Vector3 angleV;
    private bool isShake;
    public static CameraFollow instance;
    // Use this for initialization
    void Start()
    {
        instance = this;
    }

    // 每一帧的Update结束时调用
    private void LateUpdate()
    {
        if (target == null)
            return;

        if (target.position.z >= 0)
        {
            if (!isShake)
            {
                positionV.x = Mathf.Lerp(positionV.x, target.position.x, 5 * Time.deltaTime);
                positionV.y = Mathf.Lerp(positionV.y, target.position.y + height, 5*Time.deltaTime);
                positionV.z = Mathf.Lerp(positionV.z, target.position.z + distance, GameAttribute.gameAttribute.speed);
                transform.position = positionV;
                angleV.x = angle;
                angleV.y = Mathf.Lerp(angleV.y, 0, 1 * Time.deltaTime);
                angleV.z = transform.eulerAngles.z;
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, angleV, 1 * Time.deltaTime);
            }
        }
        else
        {
            if (PatternSystem.instance.loadingComplete)
            {
                Vector3 temp = Vector3.zero;
                positionV.x = Mathf.Lerp(positionV.x, 0, 5 * Time.deltaTime);
                positionV.y = Mathf.Lerp(positionV.y, temp.y + height, 5 * Time.deltaTime);
                positionV.z = temp.z + distance;
                transform.position = positionV;
                angleV.x = angle;
                angleV.y = transform.eulerAngles.y;
                angleV.z = transform.eulerAngles.z;
                transform.eulerAngles = angleV;
            }
        }
    }

    void Reset()
    {
        initCameraFollow(Vector3.zero);
    }

    // 晃动摄像机
    public void ShakeCamrea()
    {
        isShake = true;
        StartCoroutine(doShake());
    }

    // 晃动摄像机操作
    private IEnumerator doShake()
    {
        float count = 0;
        Vector3 position = Vector3.zero;
        while (count <= 0.2f)
        {
            count += Time.smoothDeltaTime;
            position.x = transform.position.x + Random.Range(-0.05f, 0.05f);
            position.y = transform.position.y + Random.Range(-0.05f, 0.05f);
            position.z = distance;
            transform.position = position;
            yield return 0;
        }
        // 晃动完成后还原，继续稳定跟随人物
        initCameraFollow(transform.position);
    }

    // 设置跟随参数
    private void initCameraFollow(Vector3 v)
    {
        positionV.x = v.x;
        positionV.y = v.y + height;
        positionV.z = v.z + distance;
        transform.position = positionV;
        angleV.x = angle;
        angleV.y = transform.eulerAngles.y;
        angleV.z = transform.eulerAngles.z;
        transform.eulerAngles = angleV;
        isShake = false;
    }
}
