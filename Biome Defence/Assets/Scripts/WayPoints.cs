using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

    public static Transform[] points;

    private void Awake()
    {
        points = new Transform[transform.childCount];
        //This will allow us to go through each child of the WayPoints parent so that it can get each 
        //component and put into the Array.
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
