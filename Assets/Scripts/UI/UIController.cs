using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] GameObject _introUI;
    [SerializeField] GameObject _pinchInstruction;
    [SerializeField] GameObject _observationUI;
    [SerializeField] GameObject _timerEnd;
    [SerializeField] GameObject _gameEnd;
    [SerializeField] Image _timerImage;
    [SerializeField] Text _timerText;
    [SerializeField] Text _observationText;

    [SerializeField] float _initialTimerForIntro = 10f;
    [SerializeField] float _totalSeconds = 180f;
    [SerializeField] int _totalHazardObjects = 6;

    float _timeCounter;
    float _initialTimeCounter = 0;
    int _hazardObjectsFound = 0;
    bool _initialTimerOver = false;
    bool _startTimer = false;

    private void Start()
    {
        _timeCounter = _totalSeconds;
        _initialTimeCounter = _initialTimerForIntro;
        DisplayTime(_timeCounter);
    }

    private void Update()
    {
        if (!_initialTimerOver)
        {
            if(_initialTimeCounter > 0)
            {
                _initialTimeCounter -= Time.deltaTime;
            }
            else
            {
                _initialTimeCounter = _initialTimerForIntro;
                _initialTimerOver = true;
                _introUI.SetActive(false);
                _pinchInstruction.SetActive(true);
            }
        }
        if(_startTimer)
        {
            if(_timeCounter >= 0)
            {
                _timeCounter -= Time.deltaTime;
                DisplayTime(_timeCounter);
            }
            else
            {
                _startTimer = false;
                _observationUI.SetActive(false);
                _timerEnd.SetActive(true);
            }
        }
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _observationText.text = "Observation\n" + _hazardObjectsFound + '/' + _totalHazardObjects;
        _timerImage.fillAmount = _timeCounter / _totalSeconds;
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddTime(float _timeToBeAdded)
    {
        _startTimer = true;
        _timeCounter = _timeToBeAdded;
        _observationUI.SetActive(true);
        _timerEnd.SetActive(false);
    }

    public void StartGameUI()
    {
        _observationUI.SetActive(true);
        _startTimer = true;
    }

    public void RestartGameUI()
    {
        _initialTimeCounter = _initialTimerForIntro;
        _introUI.SetActive(true);
        _initialTimerOver = true;
    }
}
