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

    void OnMouseEnter()
    {
        mat.color = Color.green;
        Sensor.text = "围岩压力及钢筋应力监测";
        if (force > 200 || force2 > 300)
        {
            Value.text = "围岩压力：" + force + "KN  钢筋应力：" + force2 + "kPa\n" +
                "超过预警值，危险！！！";
        }
        else
        {
            Value.text = "围岩压力：" + force + "KN\n钢筋应力：" + force2 + "kPa";
        }

    }

    void OnMouseExit()
    {
        mat.color = col;
        Sensor.text = "";
        Value.text = "";
    }
}
