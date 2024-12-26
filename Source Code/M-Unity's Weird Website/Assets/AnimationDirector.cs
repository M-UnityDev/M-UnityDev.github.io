using DG.Tweening;
using UnityEngine;
using Unity.Burst;
[BurstCompile]
public class AnimationDirector : MonoBehaviour
{
    public enum BodyPart
    {
        ArmLeft,
        ArmRight,
        Body,
        LegLeft,
        LegRight,
        Head,
        Whole
    }
    public GameObject ArmLeft;
    public GameObject ArmRight;
    public GameObject Body;
    public GameObject LegLeft;
    public GameObject LegRight;
    public GameObject Head;
    private GameObject CurrentPart;
    public void MovePart(BodyPart Part, Vector3 MovePosition, float MoveDuration)
    {
        if (Part.Equals(BodyPart.Whole)) CurrentPart = gameObject;
        else CurrentPart = GetType().GetField(Part.ToString()).GetValue(this) as GameObject;
        CurrentPart.transform.DOLocalMove(MovePosition,MoveDuration);
    }
    public void RotatePart(BodyPart Part, Vector3 RotatePosition, float RotateDuration)
    {
        if (Part.Equals(BodyPart.Whole)) CurrentPart = gameObject;
        else CurrentPart = GetType().GetField(Part.ToString()).GetValue(this) as GameObject;
        CurrentPart.transform.DOLocalRotate(RotatePosition,RotateDuration);
    }
    public void DefaultMove()
    {
        MovePart(BodyPart.Whole, new Vector3 (2,0,0), 1);
        RotatePart(BodyPart.Whole, new Vector3 (0,-90,0), 2);
        RotatePart(BodyPart.ArmLeft, new Vector3 (-125,0,0), 2);
    }
}
