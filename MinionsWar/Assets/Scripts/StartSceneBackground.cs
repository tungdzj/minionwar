using UnityEngine;
using System.Collections;

public class StartSceneBackground : MonoBehaviour
{
    //public GameObject[] panels;
    private GameObject[] clouds;
    private float cloudSpeed = 1;
    private float cloudWidth = 0;
    void Start()
    {
        clouds = GameObject.FindGameObjectsWithTag("cloud");
        cloudWidth = clouds[0].GetComponent<UISprite>().width;
        AnimateClouds();
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
        if (des.x < 0)
        {
            obj.transform.localPosition = new Vector3(Screen.width + cloudWidth, des.y, des.z);
        }
        iTween.MoveTo(obj, iTween.Hash(
                "islocal", true,
                "position", new Vector3(-cloudWidth, des.y, des.z),
                "speed", Random.Range(Screen.width / 5, Screen.width / 4),
                "easetype", "linear",
                "oncomplete", "resetCloud",
                "oncompleteparams", obj,
                "oncompletetarget", this.gameObject));
    }
}
