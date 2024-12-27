using UnityEngine;
using DG.Tweening;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform LogoText;
    private int pos = 128;
    private void Start()
    {
        DOTween.To(() => pos, x => pos = x, 0, 1).OnUpdate(() => {
            LogoText.offsetMin = new Vector2(LogoText.offsetMin.x, pos);
        }).SetEase(Ease.InFlash);
    }
    public void StartGame()
    {
        
    }
}
