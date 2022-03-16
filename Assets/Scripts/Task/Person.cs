using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Person : MonoBehaviour
    {
        [SerializeField] private PersonButton baseButton;
        private PersonPrefabData personPrefabData;
        [SerializeField] private StreamingAssetsController streamingAssetsController;
        


        private List<GameObject> genderButtons;

        private PersonConfig config;

        private GameObject currentPerson = null;

        private void Start()
        {
            genderButtons = new List<GameObject>();
            config = Resources.Load<PersonConfig>("Task/PersonConfig");
            var names = config.Models;
            
            var names2 = config.ArmorColors;
            
            foreach (var objName in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                Debug.Log(objName);
                btn.Setup(objName, OnCreateButton);
                btn.gameObject.SetActive(true);
            }
            

            
            /*foreach (var objName in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                Debug.Log(objName);
                btn.Setup(objName, OnCreateButton);
                btn.gameObject.SetActive(true);
            }*/
            
            //baseButton.Setup("Random", OnRandomEffectButton);
        }
        

        private void OnCreateButton(string id)
        {
            if (genderButtons.Count > 0)
            {
                for (int i = 0; i < genderButtons.Count; i++)
                {
                    Destroy(genderButtons[i]);
                }
            }
            
            var asset = config.GetModel(id);
            if (currentPerson != null)
            {
                Destroy(currentPerson);
            }
            
            currentPerson = Instantiate(asset);
            personPrefabData = currentPerson.GetComponent<PersonPrefabData>();

            streamingAssetsController.gender = personPrefabData.CurrentGender;
            
            streamingAssetsController.GetTexturesByGender();
            var names1 = streamingAssetsController.CurrentTexture;
            
            foreach (var objName in names1)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                genderButtons.Add(btn.gameObject);
                btn.Setup(objName.name, OnChangeHairColorButton);
                btn.gameObject.SetActive(true);
            }
        }

        private void OnChangeHairColorButton(string id)
        {
            if (currentPerson != null)
            {
                var asset = streamingAssetsController.GetTexture(id);
                personPrefabData.HairRenderer.material.mainTexture = asset;
            }
        }
    }
}