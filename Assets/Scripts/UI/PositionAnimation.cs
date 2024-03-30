using Nova;
using System;
using UnityEngine;

[Serializable]
public struct PositionAnimation : IAnimation
{
    public Vector3 Start;
    public Vector3 End;
    public Transform TransformToMove;

    public void Update(float percentDone)
    {
        TransformToMove.localPosition = Vector3.Lerp(Start, End, percentDone);
    }
}