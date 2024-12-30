using UnityEngine;
using System.Collections;
using DG.Tweening;
using Unity.Burst;
[BurstCompile]
public class CutsceneDirector : MonoBehaviour
{
    [SerializeField] private AnimationDirector MUnity;
    [SerializeField] private DarkDirector Dark;
    [SerializeField] private GameObject UICanvas;
    [SerializeField] private GameObject MenuCamera;
    [SerializeField] private GameObject CutCamera1;
    [SerializeField] private GameObject CutCamera2;
    [SerializeField] private GameObject Lights;
    [SerializeField] private GameObject Chair;
    [SerializeField] private ChangeMaterials LaptopScreen;
    [SerializeField] private ChangeMaterials MUnityHead;
    [SerializeField] private Material[] WakeMaterial;
    [SerializeField] private Material[] HappyMaterial;
    [SerializeField] private GameObject RunningCactus;
    private void Awake()
    {

    }
    public void CutSceneStart()
    {
        StartCoroutine(nameof(CutScene));
    }
    private IEnumerator CutScene()
    {
        yield return new WaitForSeconds(1);
        MenuCamera.SetActive(false);
        yield return new WaitForSeconds(1);
        Destroy(UICanvas);
        yield return new WaitForSeconds(1);
        Dark.UnDark();
        yield return new WaitForSeconds(3);
        Lights.SetActive(true);
        LaptopScreen.Change();
        yield return new WaitForSeconds(2);
        CutCamera1.SetActive(false);
        MUnity.RotatePart(AnimationDirector.BodyPart.Head,new Vector3(35,0,0),4, Ease.Linear);
        yield return new WaitForSeconds(4);
        MUnityHead.Change(WakeMaterial);
        MUnity.RotatePart(AnimationDirector.BodyPart.Head,new Vector3(0,0,0),0.5f, Ease.OutBounce);
        yield return new WaitForSeconds(2);
        MUnity.RotatePart(AnimationDirector.BodyPart.Head,new Vector3(5,-60,0),2, Ease.InOutElastic);
        yield return new WaitForSeconds(2);
        MUnity.RotatePart(AnimationDirector.BodyPart.ArmRight,new Vector3(-170,0,-15),1, Ease.InOutCubic);
        yield return new WaitForSeconds(2);
        MUnity.RotatePart(AnimationDirector.BodyPart.ArmRight,new Vector3(-20,0,0),2, Ease.InOutElastic);
        yield return new WaitForSeconds(2);
        MUnityHead.Change(HappyMaterial);
        yield return new WaitForSeconds(2);
        Chair.transform.DORotate(new Vector3(90,270,0), 1).SetEase(Ease.InOutCubic);
        CutCamera2.SetActive(false);
        yield return new WaitForSeconds(1);
        Chair.transform.DOMoveZ(-3.05f,1).SetEase(Ease.InCubic);
        Chair.transform.DORotate(new Vector3(90,0,0), 1).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(0.75f);
        Chair.transform.DOMoveX(0.5f,2).SetEase(Ease.OutCubic);
        MUnity.RotatePart(AnimationDirector.BodyPart.Head,new Vector3(0,0,0),1.5f, Ease.InOutCubic);
        MUnity.RotatePart(AnimationDirector.BodyPart.ArmRight,new Vector3(-70,0,0),1, Ease.InOutCubic);
        MUnity.RotatePart(AnimationDirector.BodyPart.ArmLeft,new Vector3(-70,0,0),1, Ease.InOutCubic);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Typing(MUnity, 0.2f));
        yield return new WaitForSeconds(2);
        MUnity.RotatePart(AnimationDirector.BodyPart.Head, new Vector3(2, -60, 0), 1, Ease.InOutCubic);
        yield return new WaitForSeconds(1.5f);
        MUnity.RotatePart(AnimationDirector.BodyPart.Head, new Vector3(0, 0, 0), 1, Ease.InOutCubic);
    }
    private IEnumerator Walking(AnimationDirector Player, float Speed)
    {
        while (true)
        {
            Player.RotatePart(AnimationDirector.BodyPart.LegRight, new Vector3(-20, 0, 0), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.LegLeft, new Vector3(20, 0, 0), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.ArmRight, new Vector3(20, 0, 0), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.ArmLeft, new Vector3(-20, 0, 0), Speed, Ease.InFlash);
            yield return new WaitForSeconds(Speed);
            Player.RotatePart(AnimationDirector.BodyPart.LegRight, new Vector3(20, 0, 0), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.LegLeft, new Vector3(-20, 0, 0), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.ArmRight, new Vector3(-20, 0, 0), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.ArmLeft, new Vector3(20, 0, 0), Speed, Ease.InFlash);
            yield return new WaitForSeconds(Speed);
        }
    }
    private IEnumerator Typing(AnimationDirector Player, float Speed)
    {
        while (true)
        {
            Player.RotatePart(AnimationDirector.BodyPart.ArmRight, new Vector3(-80, 0, -30), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.ArmLeft, new Vector3(-60, 0, 0), Speed, Ease.InFlash);
            yield return new WaitForSeconds(Speed);
            Player.RotatePart(AnimationDirector.BodyPart.ArmRight, new Vector3(-60, 0, -30), Speed, Ease.InFlash);
            Player.RotatePart(AnimationDirector.BodyPart.ArmLeft, new Vector3(-80, 0, 0), Speed, Ease.InFlash);
            yield return new WaitForSeconds(Speed);
        }
    }
}
