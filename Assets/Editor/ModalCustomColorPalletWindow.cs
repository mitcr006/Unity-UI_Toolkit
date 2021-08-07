using UnityEditor;
using UnityEngine;

public class ModalCustomColorPalletWindow : EditorWindow
{
    private ModalWindowCustomColorPallet palletToCreate;
    [MenuItem("UI Toolkit/Modal Window/Create Custom Color Pallet")]
    public static void ShowWindow()
    {
        ModalCustomColorPalletWindow instance = GetWindow<ModalCustomColorPalletWindow>("Modal Window Custom Color Pallet Generator");
        instance.palletToCreate = CreateInstance<ModalWindowCustomColorPallet>();
    }

    void OnGUI()
    {
        if (palletToCreate != null)
        {
            palletToCreate.headerColor = EditorGUILayout.ColorField("Header Color", palletToCreate.headerColor);
            palletToCreate.contentColor = EditorGUILayout.ColorField("Content Color", palletToCreate.contentColor);
            palletToCreate.confirmButtonColor = EditorGUILayout.ColorField("Confirm Button Color", palletToCreate.confirmButtonColor);
            palletToCreate.cancelButtonColor = EditorGUILayout.ColorField("Cancel Button Color", palletToCreate.cancelButtonColor);
            palletToCreate.extraButtonColor = EditorGUILayout.ColorField("Extra Button Color", palletToCreate.extraButtonColor);

            if (GUILayout.Button("Create Custom Pallet"))
            {
                if (!AssetDatabase.IsValidFolder("Assets/Resources/UI_Toolkit"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources", "UI_Toolkit");
                }

                if (!AssetDatabase.IsValidFolder("Assets/Resources/UI_Toolkit/Color_Pallets"))
                {
                    AssetDatabase.CreateFolder("Assets/Resources/UI_Toolkit", "Color_Pallets");
                }
                AssetDatabase.CreateAsset(palletToCreate, "Assets/Resources/UI_Toolkit/Color_Pallets/ModalCustomColorPallet.asset");
            }
        }
    }
}
