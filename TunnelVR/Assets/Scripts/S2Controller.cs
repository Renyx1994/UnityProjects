using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S2Controller : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;

    public Text Sensor;
    public Text Value;
    public float settlement;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
    }

    public void OnGazeEnter()
    {
        mat.color = Color.red;
        Sensor.text = "隧道拱顶沉降监测";
        if (settlement > 0.3)
        {
            Value.text = settlement + "毫米";
            Value.color = Color.red;
        }
        else
        {
            Value.text = settlement + "毫米";
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
