using UnityEngine;


/// <summary>
/// literally just for the funny sound effect lmao
/// </summary>
public class HereWeGoAgain : MonoBehaviour
{
    [SerializeField] AudioSource tetoFunnySFX;

    private void Start()
    {
        tetoFunnySFX.Play();
    }
}
