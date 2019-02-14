using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MercuryMessaging;

public class TypeCube : MonoBehaviour {

    MmRelayNode _myRelayNode;

    // Use this for initialization
    void Start () {
        _myRelayNode = GetComponent<MmRelayNode>();
    }
	
	public void BuildCube () {
        MmMessageInt typ = new MmMessageInt(1);
        _myRelayNode.MmInvoke((MmMethod)Build_Methods.Objtyp, typ, MmMessageType.MmInt,
                       new MmMetadataBlock(MmLevelFilter.Child));
    }
}
