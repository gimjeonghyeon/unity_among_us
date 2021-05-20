using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnClickOnlieButton()
    {
        Debug.Log("Click Online");
    }

    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
