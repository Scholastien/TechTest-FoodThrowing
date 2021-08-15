using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] private Canvas _canvasUI;
    public Canvas CanvasUI { get => _canvasUI; set => _canvasUI = value; }

    [SerializeField] private TextMeshProUGUI _scoreFeedback;
    [SerializeField] private TextMeshProUGUI _objectiveText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _endOfGamePanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _nextLevelPanel;

    #region subscription
    private void OnEnable()
    {
        EventHandler.InvalidItemType += InvalidVisualFeedback;
        EventHandler.CorrectItemType += CorrectVisualFeedback;

        EventHandler.GameWin += DisplayNextLevelPanel;
        EventHandler.GameLoose += DisplayGameOverPanel;
    }

    private void OnDisable()
    {
        EventHandler.InvalidItemType -= InvalidVisualFeedback;
        EventHandler.CorrectItemType -= CorrectVisualFeedback;


        EventHandler.GameWin -= DisplayNextLevelPanel;
        EventHandler.GameLoose -= DisplayGameOverPanel;
    }

    private void DisplayNextLevelPanel()
    {
        _endOfGamePanel.SetActive(true);
        _nextLevelPanel.SetActive(true);

    }

    private void DisplayGameOverPanel()
    {
        _endOfGamePanel.SetActive(true);
        _gameOverPanel.SetActive(true);
    }

    private void InvalidVisualFeedback()
    {
        _scoreFeedback.gameObject.SetActive(true);
        _scoreFeedback.text = "-20";
        _scoreFeedback.color = Color.red;
        StartCoroutine(Fader(_scoreFeedback));
    }

    private void CorrectVisualFeedback()
    {
        _scoreFeedback.gameObject.SetActive(true);
        _scoreFeedback.text = "+10";
        _scoreFeedback.color = Color.green;
        StartCoroutine(Fader(_scoreFeedback));
    }
    #endregion


    #region Buttons behaviour

    public void NextLevel()
    {
        EventHandler.CallAfterButtonNextLevelPressed();

        _endOfGamePanel.SetActive(false);
        _nextLevelPanel.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        _endOfGamePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        EventHandler.CallToReturnToMainMenu();
    }

    #endregion



    // Start is called before the first frame update
    private void Start()
    {
        Init();
        _scoreFeedback.gameObject.SetActive(false);
    }

    /// <summary>
    /// Initialize text fields
    /// </summary>
    private void Init()
    {
        _scoreFeedback.text = "";
        _objectiveText.text = "Required 0/10";
        _timerText.text = "Remaing time : 1:00";
        _scoreText.text = "Score : 0";
    }

    /// <summary>
    /// Update the Top part of the UI
    /// </summary>
    /// <param name="collected">current value of collected Items</param>
    /// <param name="maxquantity">maximum to gather in order to end the level</param>
    /// <param name="remainingTime">remaining time</param>
    /// <param name="score">current score</param>
    public void UpdateTopValues(int collected, int maxquantity, string remainingTime, int score)
    {
        _objectiveText.text = "Required " + collected + "/" + maxquantity;
        _timerText.text = "Remaing time : " + remainingTime;
        _scoreText.text = "Score : " + score;
    }

    /// <summary>
    /// Fade out a text (0 to 1)
    /// </summary>
    /// <param name="txtToFade"></param>
    /// <returns></returns>
    private IEnumerator Fader(TextMeshProUGUI txtToFade)
    {
        Color color = new Color(txtToFade.color.r, txtToFade.color.g, txtToFade.color.b, 1);
        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            txtToFade.color = color;
            yield return null;
        }
        color.a = 0;
        txtToFade.color = color;

        _scoreFeedback.gameObject.SetActive(false);
    }
}
