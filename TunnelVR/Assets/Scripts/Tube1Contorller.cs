using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tube1Contorller : MonoBehaviour {

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

    void Start ()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.GetColor("_ColorTint");
    }

    public void OnGazeEnter ()
    {
        mat.SetColor("_ColorTint", Color.yellow);
        Name.text = rockname + "(" + rate + ")";
        Rate.text = "围岩等级：" + rate;
        RQDvalue.text = "RQD值：" + RQD.ToString();
        Strength.text = strength.ToString() + "kPa  RQD:" + RQD.ToString();
        Description.text = description;
    }

    public void OnGazeExit ()
    {
        mat.SetColor("_ColorTint", col);
    }
}
