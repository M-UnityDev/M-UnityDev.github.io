using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField] private RectTransform LogoText;
    [SerializeField] private RectTransform Buttons;
    [SerializeField] private CutsceneDirector CutScene;
    private int pos = 128;
    private int posbtn = -768;
    private void Start()
    {
        DOTween.To(() => pos, x => pos = x, 0, 2).OnUpdate(() => {
            LogoText.offsetMin = new Vector2(LogoText.offsetMin.x, pos);
        }).SetEase(Ease.InFlash);
        DOTween.To(() => posbtn, x => posbtn = x, -128, 2).OnUpdate(() => {
            Buttons.anchoredPosition = new Vector2(Buttons.anchoredPosition.x, posbtn);
        }).SetEase(Ease.InFlash);
    }
    public void StartGame()
    {
        CutScene.CutSceneStart();
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MUUB");
    }
}
