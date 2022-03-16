using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class EffectPlayer : MonoBehaviour
    {
        [SerializeField] private EffectButton baseButton;

        private EffectsConfig config;

        private void Start()
        {
            config = Resources.Load<EffectsConfig>("EffectsConfig");
            var names = config.Effects;
            foreach (var objName in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                btn.Setup(objName, OnEffectButton);
            }
            
            baseButton.Setup("Random", OnRandomEffectButton);
        }

        private void OnRandomEffectButton(string id)
        {
            var asset = config.GetRandomEffect();   
            var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
            Destroy(obj, 5f);
        }

        private void OnEffectButton(string id)
        {
            var asset = config.GetEffect(id);
            var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
            Destroy(obj, 5f);
        }
    }
}