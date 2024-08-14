using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace VrGamesDev
{
    /// <summary>
    /// toogle the background html colors
    /// </summary>
    public class VRG_Html_Background : VRG_Base
    {
        [SerializeField] public bool m_Colorize = false;

        protected override IEnumerator Do()
        {
            // go to next frame
            yield return null;
        }

        private void OnValidate()
        {
            // Get all Image components in this GameObject and its children
            Image[] images = this.GetComponentsInChildren<Image>();

            // Iterate through each Image component
            foreach (Image myImage in images)
            {
                if (myImage != null && (myImage.name == "html" || myImage.name == "header" || myImage.name == "body" || myImage.name == "footer"))
                {
                    // enable each Image component
                    myImage.enabled = this.m_Colorize;
                }
            }
        }
    }
}