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
    public void MovePart(BodyPart Part, Vector3 MovePosition, float MoveDuration, Ease AnimationEase)
    {
        if (Part.Equals(BodyPart.Whole)) CurrentPart = gameObject;
        else CurrentPart = GetType().GetField(Part.ToString()).GetValue(this) as GameObject;
        CurrentPart.transform.DOLocalMove(MovePosition,MoveDuration).SetEase(AnimationEase);
    }
    public void RotatePart(BodyPart Part, Vector3 RotatePosition, float RotateDuration, Ease AnimationEase)
    {
        if (Part.Equals(BodyPart.Whole)) CurrentPart = gameObject;
        else CurrentPart = GetType().GetField(Part.ToString()).GetValue(this) as GameObject;
        CurrentPart.transform.DOLocalRotate(RotatePosition,RotateDuration).SetEase(AnimationEase);
    }
}
