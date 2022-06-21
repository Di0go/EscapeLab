using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //vars
    private Color32 defaultColor;
    private Color32 setColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.GetComponent<Text>().color = setColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.GetChild(0).gameObject.GetComponent<Text>().color = defaultColor;
    }

    public void RunGame()
    {
        SceneManager.LoadScene("BuildScene");
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene("ControlsMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        defaultColor = transform.GetChild(0).gameObject.GetComponent<Text>().color;
        setColor = new Color32(160, 160, 160, 255);
    }
}
