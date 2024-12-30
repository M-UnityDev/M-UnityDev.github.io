using UnityEngine;
using DG.Tweening;
using Unity.Burst;
[BurstCompile]
public class DarkDirector : MonoBehaviour
{
    [SerializeField] private bool IsDarkOnAwake;
    private SpriteRenderer SpriteDark;
    private Color Startcolor = new Color(0,0,0,1);
    private Color Endcolor = new Color(0,0,0,0);
    private void Awake()
    {
        SpriteDark = GetComponent<SpriteRenderer>();
        if(IsDarkOnAwake) SpriteDark.color = Startcolor; UnDark();  
    }
    public void Dark() => SpriteDark.DOColor(Startcolor,1).SetEase(Ease.InCubic);
    public void UnDark() => SpriteDark.DOColor(Endcolor,1).SetEase(Ease.InCubic);
}
