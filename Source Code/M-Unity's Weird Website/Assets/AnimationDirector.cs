using DG.Tweening;
using UnityEngine;
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
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //print(BodyPart.Body.ToString());
    }
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
        MovePart(BodyPart.Whole, new Vector3 (2,0,0), 2);
        RotatePart(BodyPart.Whole, new Vector3 (0,-90,0), 2);
        RotatePart(BodyPart.ArmLeft, new Vector3 (-125,0,0), 2);
    }
}
