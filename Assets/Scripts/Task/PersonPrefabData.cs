using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonPrefabData : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer hairRenderer;
    [SerializeField] private SkinnedMeshRenderer armorRenderer;
    [SerializeField] private string currentGender;

    public SkinnedMeshRenderer HairRenderer
    {
        get => hairRenderer;
        set => hairRenderer = value;
    }

    public SkinnedMeshRenderer ArmorRenderer
    {
        get => armorRenderer;
        set => armorRenderer = value;
    }

    public string CurrentGender => currentGender;
}
