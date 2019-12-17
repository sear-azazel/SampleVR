using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Text countdownText;
    private Coroutine countdown = null;

    public void OnEnter()
    {
        this.countdown = this.StartCoroutine(this.Countdown());
    }

    public void OnExit()
    {
        this.StopCoroutine(this.countdown);
        this.countdownText.text = string.Empty;
    }

    private IEnumerator Countdown()
    {
        const int sec = 2;
        float start = Time.realtimeSinceStartup;
        float elapsed = sec;
        do
        {
            this.countdownText.text = $"{(int)(sec - elapsed)}";
            elapsed = Time.realtimeSinceStartup - start;
            yield return null;
        } while (elapsed < sec);
        SceneManager.LoadScene("Menu");
    }
}
