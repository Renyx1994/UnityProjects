using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class MCU : MonoBehaviour {

    public GameObject righthand;
    private Vector3 fst;

    // Use this for initialization
    void Start () {
        fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
    }

	
	// Update is called once per frame
	void Update () {
        fst = righthand.GetComponent<CapsuleHand>().GetLeapHand().PalmPosition.ToVector3();
    }
}
