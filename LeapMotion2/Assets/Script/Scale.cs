using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MercuryMessaging;

public class Scale : MonoBehaviour {

    MmRelayNode _myRelayNode;
    // Use this for initialization
    void Start()
    {
        _myRelayNode = GetComponent<MmRelayNode>();
    }

    public void startInc()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Increase, true,
               new MmMetadataBlock(MmLevelFilter.Child));
    }

    public void stopInc()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Increase, false,
               new MmMetadataBlock(MmLevelFilter.Child));
    }

    public void startDec()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Decrease, true,
               new MmMetadataBlock(MmLevelFilter.Child));
    }

    public void stopDec()
    {
        _myRelayNode.MmInvoke((MmMethod)Leap_Methods.Decrease, false,
               new MmMetadataBlock(MmLevelFilter.Child));
    }
}
