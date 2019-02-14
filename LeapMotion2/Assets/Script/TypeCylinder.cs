using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MercuryMessaging;

public class TypeCylinder : MonoBehaviour {

    MmRelayNode _myRelayNode;

    // Use this for initialization
    void Start () {
        _myRelayNode = GetComponent<MmRelayNode>();
    }

    public void BuildCylinder()
    {
        MmMessageInt typ = new MmMessageInt(2);
        _myRelayNode.MmInvoke((MmMethod)Build_Methods.Objtyp, typ, MmMessageType.MmInt,
                       new MmMetadataBlock(MmLevelFilter.Child));
    }
}
