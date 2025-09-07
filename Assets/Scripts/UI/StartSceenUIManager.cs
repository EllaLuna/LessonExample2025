using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceenUIManager : MonoBehaviour
{
    [SerializeField] string firstLevelName = "Level1";
    [Header("Buttons")]
    [SerializeField] Button startButton;
    [SerializeField] Button creditsButton;
    [SerializeField] Button exitButton;
    [SerializeField] Button backButton;

    [Header("Panels")]
    [SerializeField] GameObject buttonsPanel;
    [SerializeField] GameObject creditsPanel;

    void Start()
    {

        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        AddButtonsListeners();
        ToggleCreditsScreen(false);
    }

    private void AddButtonsListeners()
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene(firstLevelName));
        creditsButton.onClick.AddListener(() => ToggleCreditsScreen(true));
        backButton.onClick.AddListener(() => ToggleCreditsScreen(false));
        exitButton.onClick.AddListener(() => Application.Quit());
    }

    private void ToggleCreditsScreen(bool showCredits)
    {
        creditsPanel.gameObject.SetActive(showCredits);
        buttonsPanel.gameObject.SetActive(!showCredits);

        EventSystem.current.SetSelectedGameObject(showCredits 
            ? backButton.gameObject : creditsButton.gameObject);
    }
}
