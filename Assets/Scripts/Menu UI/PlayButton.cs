using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

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
    [SerializeField] Button[] buttonToDisable;


    public void OnPointerEnter()
    {
        isHovered = true;
        
        if(isClicked == true)
            return;

        DOTween.Kill(playButton.transform);
        playButton.transform.DOScale(hoverScale, .5f).SetEase(Ease.OutExpo);
        playButton.transform.DORotate(new Vector3(0, 0, Random.Range(-3f, 3f)), .5f).SetEase(Ease.OutExpo);
        
    }

    public void OnPointerExit()
    {
        isHovered = false;

        if(isClicked == true)
            return;

        DOTween.Kill(playButton.transform);
        playButton.transform.DOScale(1f, 0.2f).SetEase(Ease.OutBack);
        playButton.transform.DORotate(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.OutBack);
    }

    public void OnClick()
    {
        StartCoroutine(OnClickSequence());
    }

    IEnumerator OnClickSequence()
    {
        isClicked = true;
        DOTween.Kill(playButton.transform);

        foreach (Button b in buttonToDisable)
        {
            b.interactable = false;
        }

        yield return playButton.transform.DOScale(0.9f, 0.15f).SetEase(Ease.OutExpo).WaitForCompletion();
        yield return playButton.transform.DOScale(hoverScale, 0.15f).SetEase(Ease.OutExpo).WaitForCompletion();

        WipeTransition.SceneTransition("Level Select");

        //load the game scene here
        //SceneManager.LoadScene("Level Select");
    }
}
