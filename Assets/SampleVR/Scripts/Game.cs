using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Text countdownText;
    private Coroutine countdown = null;

    private void Start()
    {
        XRUtility.IsEnabled = true;
    }

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
        const int sec = 3;
        float elapsed = 0;
        while (elapsed < sec)
        {
            this.countdownText.text = $"{(int)(sec - elapsed)}";
            elapsed += Time.fixedDeltaTime;
            yield return null;
        }
        SceneManager.LoadScene("Menu");
        XRUtility.IsEnabled = false;
    }
}
