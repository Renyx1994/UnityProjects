using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MercuryMessaging;

public enum Leap_Methods
{
    Translate = 101, Rotation = 102, Decrease = 103, Increase = 104
}


public class Translate : MonoBehaviour {

    MmRelayNode _myRelayNode;

    // Use this for initialization
    void Start()
    {
        _myRelayNode = GetComponent<MmRelayNode>();
    }

    public void startMoving()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Translate, true,
               new MmMetadataBlock(MmLevelFilter.Child));
    }

    public void stopMoving()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Translate, false,
               new MmMetadataBlock(MmLevelFilter.Child));
    }
}
