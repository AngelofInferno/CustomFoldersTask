using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

namespace DefaultNamespace
{
    public class StreamingAssetsController : MonoBehaviour
    {
        //[SerializeField] private ImageData baseIcon;
        private List<Texture2D> currentTexture;

        public List<Texture2D> CurrentTexture => currentTexture;

        public string gender;

        private void Start()
        {
            //baseIcon.gameObject.SetActive(false);
            //currentTexture = GetAllTextures();
        }
        
        public void GetTexturesByGender()
        {
            var counter = 0;
            //baseIcon.gameObject.SetActive(true);
            List<Texture2D> textures = new List<Texture2D>();
            var directoryInfo = new DirectoryInfo(Application.streamingAssetsPath);
            Debug.Log($"Streaming Assets Path {Application.streamingAssetsPath}");
            var allFiles = directoryInfo.GetFiles("*.*");
            

            for (int i = 0; i < allFiles.Length; i++)
            {
                Debug.Log($"File name {allFiles[i].Name}");

                if (allFiles[i].Name.Contains("meta"))
                {
                    continue;
                }

                if (!allFiles[i].Name.Contains(gender))
                {
                    continue;
                }

                //var imageData = Instantiate(baseIcon, baseIcon.transform.parent);

                var bytes = File.ReadAllBytes(allFiles[i].FullName);
                var texture2D = new Texture2D(1, 1);
                texture2D.name = $"Hair_{counter}";
                counter++;
                texture2D.LoadImage(bytes);
                textures.Add(texture2D);
            }

            currentTexture = textures;
        }

        public Texture2D GetTexture(string id)
        {
            foreach (var texture in currentTexture)
            {
                if (texture.name.Contains(id))
                {
                    return texture;
                }
            }

            return null;
        }
    }
}