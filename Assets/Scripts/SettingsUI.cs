using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Button mouseControlButton;
    [SerializeField] private Button keyboardMouseControlButton;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        SetButtonColor();
    }

    public void SetControlMode(int controlType)
    {
        PlayerSettings.controlType = (ControlType) controlType;
        
        SetButtonColor();
    }

    private void SetButtonColor()
    {
        switch (PlayerSettings.controlType)
        {
            case ControlType.Mouse:
                mouseControlButton.image.color = Color.green;
                keyboardMouseControlButton.image.color = Color.white;
                break;
            case ControlType.KeyboardMouse:
                mouseControlButton.image.color = Color.white;
                keyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    public void Close()
    {
        StartCoroutine("CloseAfterDelay");
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
