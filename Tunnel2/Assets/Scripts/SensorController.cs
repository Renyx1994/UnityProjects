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

    void OnMouseEnter()
    {
        mat.color = Color.green;
        Sensor.text = "锚杆拉力监测";
        if(force > 20)
        {
            Value.text = force + "KN\n" +
                "超过预警值，危险！！！";
        }
        else
        {
            Value.text = force + "KN";
        }
        
    }

    void OnMouseExit()
    {
        mat.color = col;
        Sensor.text = "";
        Value.text = "";
    }
}
