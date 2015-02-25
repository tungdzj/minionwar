using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("box1"), "time", 5));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
