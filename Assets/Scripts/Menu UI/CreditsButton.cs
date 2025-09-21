using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;

/// <summary>
/// script for credits button & credits menu
/// </summary>
public class CreditsButton : MonoBehaviour
{
    [SerializeField] Image creditsPanel;
    [SerializeField] Button creditsButton;

    int buttonMode = 0; // 0 = open, 1 = close
    [SerializeField] float buttonExpandFactor = 1.2f;
    [SerializeField] float buttonMoveDuration;
    [SerializeField] float buttonMoveAmount;

    bool isAnimating = false;

    [SerializeField] float panelExpandDuration;

    [SerializeField] Button[] buttonsToModify; //buttons in this list will "move out of the way" when credits menu is opened


    public void OnClick()
    {
        if(buttonMode == 0 && isAnimating == false) //open menu
        {   
            StartCoroutine(OpenCreditsSequence());
        }
        else if(buttonMode == 1 && isAnimating == false) //close menu
        {
            StartCoroutine(CloseCreditsSequence());
        }
    }

    public void OnPointerEnter()
    {
        if(isAnimating == false)
        {
            DOTween.Kill(creditsButton.transform);
            creditsButton.transform.DOScale(buttonExpandFactor, 0.2f).SetEase(Ease.OutBack);
        }
    }

    public void OnPointerExit()
    {
        if(isAnimating == false)
        {
            DOTween.Kill(creditsButton.transform);
            creditsButton.transform.DOScale(1f, 0.2f).SetEase(Ease.OutExpo);
        }
    }

    IEnumerator OpenCreditsSequence()
    {
        isAnimating = true;
        var credBtnTransform = creditsButton.transform;

        //disable other buttons while animating
        foreach (Button button in buttonsToModify)
        {
            button.interactable = false;
        }

        //button animation (expand, move left a bit, then contract)
        DOTween.Kill(credBtnTransform);
        var buttonSequence = DOTween.Sequence();
        buttonSequence.Append(credBtnTransform.DOScale(buttonExpandFactor * 1.15f, buttonMoveDuration)).SetEase(Ease.OutBack);
        buttonSequence.Join(credBtnTransform.DOMoveX(credBtnTransform.position.x - buttonMoveAmount, buttonMoveDuration)).SetEase(Ease.OutCubic);
        buttonSequence.Append(credBtnTransform.DOMoveX(credBtnTransform.position.x, buttonMoveDuration)).SetEase(Ease.OutCubic);

        //move other buttons to the right a little bit, reduce their opacity, and reduce size
        var sideBtnSequence = DOTween.Sequence();
        foreach(Button button in buttonsToModify)
        {
            sideBtnSequence.Join(button.transform.DOMoveX(button.transform.position.x + buttonMoveAmount / 2f, buttonMoveDuration).SetEase(Ease.OutCubic));
            sideBtnSequence.Join(button.transform.DOScale(0.75f, buttonMoveDuration).SetEase(Ease.OutCubic));
            sideBtnSequence.Join(button.image.DOFade(0.6f, buttonMoveDuration).SetEase(Ease.OutCubic));
        }

        //start collapsed at button
        creditsPanel.gameObject.SetActive(true);
        creditsPanel.transform.localScale = Vector2.zero;

        //tween to scale 1
        DOTween.Kill(creditsPanel.rectTransform);
        var sequence = DOTween.Sequence();
        sequence.Join(creditsPanel.transform.DOScale(1, panelExpandDuration).SetEase(Ease.OutBack));

        yield return sequence.WaitForCompletion();

        yield return DOTween.Sequence().Append(credBtnTransform.DOScale(1f, buttonMoveDuration).SetEase(Ease.OutExpo)).WaitForCompletion();
       
        isAnimating = false;
        buttonMode = 1; //set to close
    }

    IEnumerator CloseCreditsSequence()
    {
        isAnimating = true;
        var credBtnTransform = creditsButton.transform;

        //button animation (expand, move right a bit, then contract)
        DOTween.Kill(credBtnTransform);
        var buttonSequence = DOTween.Sequence();
        buttonSequence.Append(credBtnTransform.DOScale(buttonExpandFactor * 1.15f, buttonMoveDuration)).SetEase(Ease.OutBack);

        //move other buttons to the right a little bit, reduce their opacity, and reduce size
        var sideBtnSequence = DOTween.Sequence();
        foreach (Button button in buttonsToModify)
        {
            sideBtnSequence.Join(button.transform.DOMoveX(button.transform.position.x - buttonMoveAmount / 2f, buttonMoveDuration).SetEase(Ease.OutCubic));
            sideBtnSequence.Join(button.transform.DOScale(1f, buttonMoveDuration).SetEase(Ease.OutCubic));
            sideBtnSequence.Join(button.image.DOFade(1f, buttonMoveDuration).SetEase(Ease.OutCubic));
        }

        //tween to hide the panel
        DOTween.Kill(creditsPanel.rectTransform);
        var sequence = DOTween.Sequence();
        sequence.Join(creditsPanel.transform.DOScale(0, panelExpandDuration).SetEase(Ease.OutCubic));

        yield return new WaitForSeconds(panelExpandDuration / 1.5f);

        var credBtnFinalSequence = DOTween.Sequence();
        credBtnFinalSequence.Append(credBtnTransform.DOMoveX(credBtnTransform.position.x + buttonMoveAmount, buttonMoveDuration)).SetEase(Ease.OutCubic);
        credBtnFinalSequence.Append(credBtnTransform.DOMoveX(credBtnTransform.position.x, buttonMoveDuration)).SetEase(Ease.OutCubic);
        credBtnFinalSequence.Join(credBtnTransform.DOScale(1f, buttonMoveDuration)).SetEase(Ease.OutBack);

        yield return sequence.WaitForCompletion();

        isAnimating = false;
        buttonMode = 0; //set to close
        creditsPanel.gameObject.SetActive(false);
        foreach (Button button in buttonsToModify)
        {
            button.interactable = true;
        }
    }
}
