using UnityEngine;
using System.Collections;
public class CutsceneDirector : MonoBehaviour
{
    [SerializeField] private AnimationDirector MUnity;
    [SerializeField] private GameObject RunningCactus;
    private void Start()
    {
        StartCoroutine(Walking(MUnity,0.75f));

        //StartCoroutine(nameof(CutScene));
    }
    private void FixedUpdate()
    {
        MUnity.Head.transform.Rotate(0,15,0);
    }
    private IEnumerator CutScene()
    {
        yield return new WaitForSeconds(1);
        
    }
    private IEnumerator Walking(AnimationDirector Player, float Speed)
    {
        while(true)
        {
            Player.RotatePart(AnimationDirector.BodyPart.LegRight,new Vector3(-20,0,0), Speed);
            Player.RotatePart(AnimationDirector.BodyPart.LegLeft,new Vector3(20,0,0), Speed);
            Player.RotatePart(AnimationDirector.BodyPart.ArmRight,new Vector3(20,0,0), Speed);
            Player.RotatePart(AnimationDirector.BodyPart.ArmLeft,new Vector3(-20,0,0), Speed);
            yield return new WaitForSeconds(Speed);
            Player.RotatePart(AnimationDirector.BodyPart.LegRight,new Vector3(20,0,0), Speed);
            Player.RotatePart(AnimationDirector.BodyPart.LegLeft,new Vector3(-20,0,0), Speed);
            Player.RotatePart(AnimationDirector.BodyPart.ArmRight,new Vector3(-20,0,0), Speed);
            Player.RotatePart(AnimationDirector.BodyPart.ArmLeft,new Vector3(20,0,0), Speed);
            yield return new WaitForSeconds(Speed);
        }
    }
}
