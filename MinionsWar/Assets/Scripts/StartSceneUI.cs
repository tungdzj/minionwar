using UnityEngine;
using System.Collections;

public class StartSceneUI : MonoBehaviour
{
    public GameObject[] panels;
    private GameObject[] clouds;
    private float cloudSpeed = 1;
    private float cloudWidth = 0;
    // Use this for initialization
    void Start()
    {
        clouds = GameObject.FindGameObjectsWithTag("cloud");
        cloudWidth = clouds[0].GetComponent<UISprite>().width;
        Debug.Log(clouds.Length.ToString());
        AnimateClouds();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AnimateClouds()
    {
        foreach (GameObject c in clouds)
        {
            resetCloud(c);
        }
    }
    void resetCloud(GameObject obj)
    {
        Vector3 des = obj.transform.localPosition;
        if (des.x < -cloudWidth)
        {
            obj.transform.localPosition = new Vector3(Screen.width, des.y, des.z);
        }
        iTween.MoveTo(obj, iTween.Hash(
                "position", new Vector3(100, 0, 0),
                "speed", Random.Range(1, 2),
                "oncomplete", "resetCloud",
                "oncompleteparams", obj,
                "oncompletetarget", this.gameObject));
    }

    public void OnPlayClick()
    {
        Application.LoadLevel("main");
    }
}
