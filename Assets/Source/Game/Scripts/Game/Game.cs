using AYellowpaper;
using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Game : MonoBehaviour
{
    [SerializeField] private InterfaceReference<BaseInput, MobileInput> _mobileInput;
    [SerializeField] private InterfaceReference<BaseInput, DesktopInput> _desktopInput;

    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _uiSounds;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _continueButton;

    [SerializeField] private Tutorial _tutorialPrefab;
    [SerializeField] private GameplayWindow _gameplayWindow;

    private Tutorial _currentTutorial;
    private float _defaultMusicVolume;

    public event Action Started;

    private void Start()
    {
        _pauseButton.onClick.AddListener(Pause);
        _continueButton.onClick.AddListener(Resume);

        _defaultMusicVolume = _music.volume;

        if (YandexGame.savesData.isNewPlayer)
        {
            LaunchTutorial();
        }
        else
        {
            GameStart();
        }
    }

    private void LaunchTutorial()
    {
        _currentTutorial = Instantiate(_tutorialPrefab);
        _currentTutorial.Init(_uiSounds);
        YandexGame.savesData.isNewPlayer = false;

        Pause();
    }

    private void GameStart()
    {
        if (YandexGame.EnvironmentData.isDesktop)
        {
            ActivateDesktopInput();
        }
        else
        {
            ActivateMobileInput();
        }

        Resume();

        Started?.Invoke();
    }

    private void Pause()
    {
        float volumeMultiplier = 0.25f;

        Time.timeScale = 0f;
        _music.volume *= volumeMultiplier;
        _gameplayWindow.Hide();
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        _music.volume = _defaultMusicVolume;
        _gameplayWindow.Show();

        Debug.Log("gameplay winow shown");
    }

    private void ActivateMobileInput()
    {
        _mobileInput.Value.enabled = true;
        _desktopInput.Value.enabled = false;
    }

    private void ActivateDesktopInput()
    {
        _mobileInput.Value.enabled = false;
        _desktopInput.Value.enabled = true;
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveListener(Pause);
        _continueButton.onClick.RemoveListener(Resume);
    }
}
