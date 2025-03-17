using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverImage;
    public Sprite gameClearImage;
    public GameObject restartButton;
    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("InactivateMainImage", 1.0f); // 1초뒤에 InactivateMainImage()를 호출
        restartButton.SetActive(false);
        nextButton.SetActive(false);

        // 버튼 이벤트 등록
        restartButton.GetComponent<Button>().onClick.AddListener(HandleRestartButton);
        nextButton.GetComponent<Button>().onClick.AddListener(HandleNextButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameState == "gameClear")
        {
            mainImage.GetComponent<Image>().sprite = gameClearImage;
            mainImage.SetActive(true);
            restartButton.SetActive(true);
            nextButton.SetActive(true);
            restartButton.GetComponent<Button>().interactable = false; // 버튼을 클릭하지 못하도록 비활성화
            PlayerController.gameState = "gameEnd";
        }
        else if (PlayerController.gameState == "gameOver")
        {
            mainImage.GetComponent<Image>().sprite = gameOverImage;
            mainImage.SetActive(true);
            restartButton.SetActive(true);
            nextButton.SetActive(true);
            nextButton.GetComponent<Button>().interactable = false; // 버튼을 클릭하지 못하도록 비활성화
            PlayerController.gameState = "gameEnd";
        }
    }

    void InactivateMainImage()
    {
        mainImage.SetActive(false);
    }

    void HandleRestartButton()
    {
        Debug.Log("Restart");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void HandleNextButton()
    {
        Debug.Log("Next");
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
    }
}
