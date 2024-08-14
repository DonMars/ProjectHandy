using System.Collections;

using UnityEngine;
using UnityEngine.UI;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{
    ///#IGNORE
    public class Example_Remote_Switcher : VRG_Base
    {
        [SerializeField] private Text m_Text = null;

        [SerializeField] private Transform m_True = null;

        [SerializeField] private Transform m_False = null;

        ///#IGNORE
        protected override IEnumerator Do()
        {
            if (this.m_Text.text == "True")
            {
                this.m_True.gameObject.SetActive(true);
            }
            else
            {
                this.m_False.gameObject.SetActive(true);
            }

            yield return null;
        }
    }
}