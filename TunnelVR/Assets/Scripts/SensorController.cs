using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensorController : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;

    public Text Sensor;
    public Text Value;
    public float force;

    void Start () {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
    }

    public void OnGazeEnter()
    {
        mat.color = Color.green;
        Sensor.text = "锚杆拉力监测";
        if(force > 20)
        {
            Value.text = force + "KN";
            Value.color = Color.red;
        }
        else
        {
            Value.text = force + "KN";
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
