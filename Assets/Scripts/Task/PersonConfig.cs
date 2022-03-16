using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu]
    public class PersonConfig : ScriptableObject
    {
        [SerializeField] private string[] models;
        [SerializeField] private string[] hairColors;
        [SerializeField] private string[] armorColors;

        public string[] Models => models;
        public string[] HairColors => hairColors;
        public string[] ArmorColors => armorColors;
        

        public GameObject GetModel(string modelName)
        {
            var objName = models.FirstOrDefault(m => m == modelName);
            return (string.IsNullOrEmpty(objName) ? null : LoadObject($"Task/Models/{modelName}"));
        }
        
        public Material GetHairColor(string hairName)
        {
            var objName = models.FirstOrDefault(m => m == hairName);
            return (string.IsNullOrEmpty(objName) ? null : LoadMaterial($"Task/HairColors/{hairName}"));
        }

        private static Material LoadMaterial(string path)
        {
            return Resources.Load<Material>(path);
        }
        
        private static GameObject LoadObject(string path)
        {
            return Resources.Load<GameObject>(path);
        }
        
#if UNITY_EDITOR
        private void Reset()
        {
            var loadedModels = Resources.LoadAll<GameObject>($"Task/Models");
            models = new string[loadedModels.Length];

            for (int i = 0; i < models.Length; i++)
            {
                models[i] = loadedModels[i].name;
            }
            
            var loadedHairColors = Resources.LoadAll<Material>($"Task/HairColors");
            Debug.Log(loadedModels.Length);
            hairColors = new string[loadedHairColors.Length];

            for (int i = 0; i < hairColors.Length; i++)
            {
                hairColors[i] = loadedHairColors[i].name;
            }
            
            var loadedArmorColors = Resources.LoadAll<Material>($"Task/ArmorColors");
            armorColors = new string[loadedArmorColors.Length];

            for (int i = 0; i < armorColors.Length; i++)
            {
                armorColors[i] = loadedArmorColors[i].name;
            }
        }
#endif        
    }
}