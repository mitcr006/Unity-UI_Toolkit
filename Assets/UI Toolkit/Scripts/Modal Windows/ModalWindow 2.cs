using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class ModalWindow : MonoBehaviour
{

    [Header("Header")]
    [SerializeField]
    private Transform headerTransform;
    [SerializeField]
    public TextMeshProUGUI headerTextField;

    [Header("Content")]
    [SerializeField]
    private Transform contentTransform;
    [SerializeField]
    public TextMeshProUGUI contentTextField;
    [SerializeField]
    private GameObject contentImageGameObject;
    [SerializeField]
    public Image contentImage;


    [Header("Footer")]
    [SerializeField]
    private Transform footerTransform;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    public TextMeshProUGUI confirmButtonText;
    [Space]
    [SerializeField]
    private Button extraButton;
    [SerializeField]
    public TextMeshProUGUI extraButtonText;
    [Space]
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    public TextMeshProUGUI cancelButtonText;

    [SerializeField]
    private Image headerColor;
    [SerializeField]
    private Image contentColor;
    [SerializeField]
    private Image confirmButtonColor;
    [SerializeField]
    private Image cancelButtonColor;
    [SerializeField]
    private Image extraButtonColor;

    private Action onConfirmAction;
    private Action onExtraAction;
    private Action onCancelAction;


    public  void Confirm()
    {
        onConfirmAction?.Invoke();
        Close();
    }

    public void Decline()
    {
        onCancelAction?.Invoke();
        Close();
    }

    public void Alternative()
    {
        onExtraAction?.Invoke();
        Close();
    }

    private void Close()
    {
        Destroy(this.gameObject);
    }

    public void CreateModalWindow(ModalWindowObjectNode modalNode, Action confirm, Action additional, Action cancel)
    {
        onConfirmAction += confirm;
        onCancelAction += cancel;
        onExtraAction += additional;

        if (modalNode.headerText.Length != 0)
        {
            headerTransform.gameObject.SetActive(true);
            headerTextField.text = modalNode.headerText;
        }

        contentTextField.text = modalNode.bodyText;
        if (modalNode.bodyImage != null)
        {
            contentImageGameObject.SetActive(true);
            contentImage.sprite = modalNode.bodyImage;
        }

        confirmButtonText.text = modalNode.confirmButtonText;

        if (modalNode.additionalButtonText.Length != 0)
        {
            extraButton.gameObject.SetActive(true);
            extraButtonText.text = modalNode.additionalButtonText;
        }

        if (modalNode.cancelButtonText.Length != 0)
        {
            cancelButton.gameObject.SetActive(true);
            cancelButtonText.text = modalNode.cancelButtonText;
        }
        ApplyCustomColorPallet();
    }
    private void ApplyCustomColorPallet()
    {
        ModalWindowCustomColorPallet customPallet = Resources.Load<ModalWindowCustomColorPallet>("UI_Toolkit/Color_Pallets/ModalCustomColorPallet");
        if (customPallet != null)
        {
            headerColor.color = customPallet.headerColor;
            contentColor.color = customPallet.contentColor;
            confirmButtonColor.color = customPallet.confirmButtonColor;
            cancelButtonColor.color = customPallet.cancelButtonColor;
            extraButtonColor.color = customPallet.extraButtonColor;
        }
    }
}
