using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField] private GameObject[] _birds;
    private bool _isGreenBirdUnlocked, _isRedBirdUnlocked;

    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        CheckIfBirdsAreUnlocked();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void CheckIfBirdsAreUnlocked()
    {
        _isGreenBirdUnlocked = GameController.instance.IsGreenBirdUnlocked();
        _isRedBirdUnlocked = GameController.instance.IsRedBirdUnlocked();
    }

    public void StartGame()
    {
        SceneFader.instance.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ChangeBirdsColor()
    {
        if (GameController.instance.GetSelectedBird() == 0)
        {
            if (_isGreenBirdUnlocked)
            {
                _birds[0].SetActive(false);
                GameController.instance.SetSelectedBird(1);
                _birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
            else if (_isRedBirdUnlocked)
            {
                _birds[0].SetActive(false);
                GameController.instance.SetSelectedBird(2);
                _birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        }

        else if (GameController.instance.GetSelectedBird() == 1)
        {
            if (_isRedBirdUnlocked)
            {
                _birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(2);
                _birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
            else
            {
                _birds[1].SetActive(false);
                GameController.instance.SetSelectedBird(0);
                _birds[GameController.instance.GetSelectedBird()].SetActive(true);
            }
        }

        else if (GameController.instance.GetSelectedBird() == 2)
        {
            _birds[2].SetActive(false);
            GameController.instance.SetSelectedBird(0);
            _birds[GameController.instance.GetSelectedBird()].SetActive(true);
        }
    }
}
