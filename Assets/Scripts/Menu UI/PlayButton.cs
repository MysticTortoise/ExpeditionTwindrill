using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// overcomplicated script for play button effects
/// 
/// </summary>
public class PlayButton : MonoBehaviour
{
    bool isHovered = false;
    bool isClicked = false;
    [SerializeField] Button playButton;
    [SerializeField] float hoverScale = 1.25f;


    public void OnPointerEnter()
    {
        isHovered = true;
        
        DOTween.Kill(playButton.transform);
        playButton.transform.DOScale(hoverScale, .5f).SetEase(Ease.OutExpo);
        playButton.transform.DORotate(new Vector3(0, 0, Random.Range(-3f, 3f)), .5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            Debug.Log($"new scale: {playButton.transform.localScale.magnitude}");
        });
        
    }

    public void OnPointerExit()
    {
        isHovered = false;

        DOTween.Kill(playButton.transform);
        playButton.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        playButton.transform.DORotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.OutBack);
    }

    public void OnClick()
    {
        isClicked = true;

        DOTween.Kill(playButton.transform);
        //DOTween.Kill(playButton.transform);
        playButton.transform.DOScale(0.9f, 0.15f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            playButton.transform.DOScale(hoverScale, 0.15f).SetEase(Ease.OutExpo);

        });

    }
}
