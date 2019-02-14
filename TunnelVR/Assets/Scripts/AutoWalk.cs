using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWalk : MonoBehaviour {

    public float speed = 3.0f;
    public bool moveforward;
    private CharacterController controller;
    private Transform vrHead;

    void Start () {
        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;
	}
	
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            moveforward = !moveforward;
        }
        if (moveforward)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
	}
}
