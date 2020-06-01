using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
	static UIManager instance;

	public TMP_Text goldText;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this);
    }

    void Start()
    {
		GameManager.onPlayerWon += GoToScreen;
		GameManager.onRestart += GoToScreen;
    }

    #region General Functions
    public void GoToScreen(int screen)
	{
		SceneManager.LoadScene(screen);
	}
    #endregion

    #region Main Menu Functions
    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Gameplay Functions
    public void IncreaseScore(int scoreIncrement)
	{
		goldText.text = "Gold: " + GameManager.gold;
    }
    #endregion
}