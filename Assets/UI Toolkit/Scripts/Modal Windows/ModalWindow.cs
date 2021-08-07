using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ModalWindow : MonoBehaviour
{
    ModalWindowObjectNode modalNode;

    [Header("Header")]
    [SerializeField]
    private Transform headerTransform;
    [SerializeField]
    private TextMeshProUGUI headerTextField;

    [Header("Content")]
    [SerializeField]
    private Transform contentTransform;
    [SerializeField]
    private TextMeshProUGUI contentTextField;
    [SerializeField]
    private GameObject contentImageGameObject;
    [SerializeField]
    private Image contentImage;


    [Header("Footer")]
    [SerializeField]
    private Transform footerTransform;
    [SerializeField]
    private Button confirmButton;
    [SerializeField]
    private TextMeshProUGUI confirmButtonText;
    [Space]
    [SerializeField]
    private Button extraButton;
    [SerializeField]
    private TextMeshProUGUI extraButtonText;
    [Space]
    [SerializeField]
    private Button cancelButton;
    [SerializeField]
    private TextMeshProUGUI cancelButtonText;

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

    public void CreateModalWindow(ModalWindowObjectNode modalWindowNode, Action confirm, Action additional, Action cancel)
    {
        modalNode = modalWindowNode;
        AssignActions(confirm, additional, cancel);
        AssignHeaderData();
        AssignContentData();
        AssignButtonData();
        ApplyCustomColorPallet();
    }

    private void AssignActions(Action confirm, Action additional, Action cancel)
    {
        onConfirmAction += confirm;
        onCancelAction += cancel;
        onExtraAction += additional;
    }

    private void AssignHeaderData()
    {
        if (modalNode.headerText.Length != 0)
        {
            headerTransform.gameObject.SetActive(true);
            headerTextField.text = modalNode.headerText;
        }
    }

    private void AssignContentData()
    {
        contentTextField.text = modalNode.bodyText;
        if (modalNode.bodyImage != null)
        {
            contentImageGameObject.SetActive(true);
            contentImage.sprite = modalNode.bodyImage;
        }
    }

    private void AssignButtonData()
    {
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
