using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TubeController : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;

    public Text Name;
    public Text Rate;
    public Text RQDvalue;
    public Text Strength;
    public Text Description;

    public string rockname;
    public string rate;
    public float RQD;
    public float strength;
    public string description;

    void Start () {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
    }

    public void OnGazeEnter()
    {
        mat.color = Color.yellow;
        Name.text = rockname + "(" + rate + ")";
        Rate.text = "围岩等级：" + rate;
        RQDvalue.text = "RQD值：" + RQD.ToString();
        Strength.text = strength.ToString() + "kPa  RQD:" + RQD.ToString();
        Description.text = description;
    }

    public void OnGazeExit()
    {
        mat.color = col;
    }
}
