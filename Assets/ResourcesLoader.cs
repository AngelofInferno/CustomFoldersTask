using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourcesLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer baseSprite;
        [SerializeField] private Transform prefabRoot;

        [SerializeField] private string[] icons = new string[2];

        private GameObject currentPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetupIcon(icons[0]);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetupIcon(icons[1]);
            }
        }

        private void SetupIcon(string configName)
        {
            var config = Resources.Load<IconInfo>($"Configs/{configName}");
            var sprite = Resources.Load<Sprite>($"Icons/{config.IconName}");
            var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");
            
            Debug.Log($"Icons/{config.IconName}");

            baseSprite.sprite = sprite;

            if (currentPrefab != null)
            {
                Destroy(currentPrefab);
            }

            currentPrefab = Instantiate(prefab, prefabRoot);
        }
    }
}