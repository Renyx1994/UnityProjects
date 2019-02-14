using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaultController : MonoBehaviour {

    private MeshRenderer mr;
    private Material mat;
    private Color col;

    public Text Name;
    public Text Rate;
    public Text RQDvalue;
    public Text Strength;
    public Text Description;

    public string rockname;
    public string description;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        col = mat.color;
    }

    void OnMouseEnter()
    {
        mat.color = new Color(1.0f,0.92f,0.016f,0.5f);
        Name.text = rockname;
        Rate.text = "围岩等级：---";
        RQDvalue.text = "RQD值：---";
        Strength.text = "强度：---";
        Description.text = description;
    }

    void OnMouseExit()
    {
        mat.color = col;
    }
}
