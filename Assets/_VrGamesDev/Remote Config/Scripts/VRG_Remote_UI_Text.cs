using System.Collections;
using System.Diagnostics;
using UnityEngine;

using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace VrGamesDev
{
    /// <summary>
    /// toogle the background html colors
    /// </summary>
    public class VRG_Remote_UI_Text : VRG_Base
    {
        [SerializeField] public Text m_Text = null;

        [SerializeField] public ENUM_DataType m_RemoteType = ENUM_DataType.NONE;

        [SerializeField] public string m_RemoteKey = "[KEY]";


        [Header("From: OnLoad")]
        /// <summary>
        /// Array of the transform to activate <em>setActive(true)</em>
        /// </summary>
        [Tooltip("Array of the transform to activate setActive(true)")]
        [SerializeField] protected Transform[] m_Activate = null;

        protected override IEnumerator Do()
        {
            yield return VRG_Remote.IsValid();

            if (this.m_Text == null)
            {
                this.m_Text = this.GetComponent<Text>();
            }

            if (this.m_Text == null)
            {
                this.Logs
                (
                    "No UI Text componente detected or assigned", 
                    "VRG_Remote_UI_Text->Do()",
                    ENUM_Verbose.ERROR
                );
            }
            else
            {
                switch (this.m_RemoteType)
                {
                    case ENUM_DataType.NONE:
                        this.Logs
                        (
                            "No ENUM_DataType assigned (" + this.transform.parent.name + "->" + this.name + ")", 
                            "VRG_Remote_UI_Text->Do()",
                            ENUM_Verbose.ERROR
                        );
                    break;

                    case ENUM_DataType.BOOL:
                        this.m_Text.text = VRG_Remote.GetBool(this.m_RemoteKey).ToString();
                    break;

                    case ENUM_DataType.INT:
                        this.m_Text.text = VRG_Remote.GetInt(this.m_RemoteKey).ToString();
                    break;

                    case ENUM_DataType.FLOAT:
                        this.m_Text.text = VRG_Remote.GetFloat(this.m_RemoteKey).ToString();
                    break;

                    case ENUM_DataType.STRING:
                        this.m_Text.text = VRG_Remote.GetString(this.m_RemoteKey);
                    break;
                }
            }

            foreach (Transform child in this.m_Activate)
            {
                if (child != null)
                {
                    child.gameObject.SetActive(true);
                }
            }

            // go to next frame
            yield return null;
        }
    }
}