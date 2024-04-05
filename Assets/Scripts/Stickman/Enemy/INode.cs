using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INode 
{
    public enum ENodeState
    {
        ERunning,
        ESuccess,
        EFailure,
    }

    public ENodeState Evaluate();
}
