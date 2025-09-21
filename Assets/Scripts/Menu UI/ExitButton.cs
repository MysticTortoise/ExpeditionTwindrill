using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;

/// <summary>
/// yet another overcomplicated script for exit button effects
/// </summary>
public class ExitButton : MonoBehaviour
{
    bool exitGame = false; // if true, next press exits the game
    bool isAnimating = false;

    [SerializeField] Button exitButton;
    [SerializeField] Image promptBackground;
    [SerializeField] TextMeshProUGUI promptText; //the one that says "EXIT GAME confirm?"
    [SerializeField] TextMeshProUGUI promptTimerText;
    [SerializeField] TextMeshProUGUI promptTextFinal; //the one that says "EXIT GAME"

    Vector3 textExpandInitSize = new Vector3(0.85f, 0.85f, 0); //final size is always 1
    Vector3 buttonInitialSize = new Vector3(64, 64, 0);
    Vector3 finalPromptTxtFinalSize = new Vector3(164, 50, 0);
    [SerializeField] Vector3 finalPromptTxtInitSize = new Vector3(0.85f, 0.85f, 0);
    [SerializeField] Vector2 buttonExpandFinalSize;

    /// <summary>
    /// brings up a confirmation dialog to exit the game
    /// </summary>
    public void OnClick()
    {
        if (exitGame != true && isAnimating != true)
        {
            StartCoroutine(ExitPromptSequence());
        }
        else if (exitGame == true)
        {
            Application.Quit();
        }
    }

    IEnumerator ExitPromptSequence()
    {
        isAnimating = true;

        //set initial text scale
        promptText.transform.localScale = textExpandInitSize;
        promptTimerText.transform.localScale = textExpandInitSize;
        promptTextFinal.transform.localScale = textExpandInitSize;

        exitButton.image.DOFade(0f, 0.3f);
        promptBackground.DOFade(1f, 0.3f);
        exitButton.image.rectTransform.DOSizeDelta(buttonExpandFinalSize, 0.8f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            promptText.transform.DOScale(1, 0.2f).SetEase(Ease.OutBack);
            promptTimerText.transform.DOScale(1, 0.2f).SetEase(Ease.OutBack);
            promptText.DOFade(1f, 0.1f);
            promptTimerText.DOFade(1f, 0.1f);
        });

        //countdown & update timer
        promptTimerText.text = "(2)";
        yield return new WaitForSeconds(1);
        promptTimerText.text = "(2)";
        yield return new WaitForSeconds(1);
        promptTimerText.text = "(1)";
        yield return new WaitForSeconds(1);

        //final exit animation
        promptText.DOFade(0f, 0.1f);
        promptTimerText.DOFade(0f, 0.1f);
        promptTextFinal.rectTransform.DOSizeDelta(finalPromptTxtFinalSize, 0.15f).SetEase(Ease.OutBack);
        promptTextFinal.DOFade(1f, 0.15f).OnComplete(() =>
        {
            exitGame = true;
            isAnimating = false;
        });


        //wait 5 seconds and reset if player doesn't exit
        yield return new WaitForSeconds(5);
        exitGame = false;
        isAnimating = true;


        promptTextFinal.rectTransform.DOSizeDelta(finalPromptTxtInitSize, 0.2f).SetEase(Ease.OutExpo);
        promptTextFinal.DOFade(0f, 0.1f).OnComplete(() =>
        {
            exitButton.image.DOFade(1f, 0.3f);
            promptBackground.DOFade(0f, 0.3f);
            exitButton.image.rectTransform.DOSizeDelta(buttonInitialSize, 0.8f).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                isAnimating = false;
            });
        });
        

    }
}
