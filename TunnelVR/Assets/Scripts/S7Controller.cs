using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S7Controller : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;

    public Text Sensor;
    public Text Value;
    public float force;
    public float force2;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
    }

    public void OnGazeEnter()
    {
        mat.color = Color.green;
        Sensor.text = "围岩压力钢筋应力";
        if (force > 200 || force2 > 300)
        {
            Value.text = force + "KN, " + force2 + "kPa";
            Value.color = Color.red;
        }
        else
        {
            Value.text = force + "KN, " + force2 + "kPa";
            Value.color = Color.white;
        }

    }

    public void OnGazeExit()
    {
        mat.color = col;
        Value.color = Color.white;
        Sensor.text = "";
        Value.text = "";
    }
}
