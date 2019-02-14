using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MercuryMessaging;

public class Rot : MonoBehaviour {

    MmRelayNode _myRelayNode;
    // Use this for initialization
    void Start () {
        _myRelayNode = GetComponent<MmRelayNode>();
    }

    public void startRot()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Rotation, true,
               new MmMetadataBlock(MmLevelFilter.Child));
    }

    public void stopRot()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Rotation, false,
               new MmMetadataBlock(MmLevelFilter.Child));
    }
}
