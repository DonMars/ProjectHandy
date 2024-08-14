/*
/*/
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// VRG_BHEL Namespace, Beautiful Html Enhanced Logs, let get you the most useful
/// and well documented logs to track bugs, or follow the flow of your game.
/// You can custom:<br></br>
/// - The level of verbosity,
/// - Where and how they will be saved,
/// - and the Html visuals,<br></br>
/// By default is in a preconfigured folder. You can find the Logs, in the
/// “[Your-project's-name] / LogsLocal / [Your-project's-name].html"
///
/// You can download it from <a href="https://assetstore.unity.com/packages/slug/186164">here</a>
/// </summary>
namespace VrGamesDev.BHEL
{
    /// <summary>
    /// Colored debug simplified
    /// </summary>
    public class VRG_Bhel : VRG_Base
    {
        /// <summary>
        /// The delay time the UI screen will wait before dissapearing
        /// </summary>
        [Range(0.0f, 9.9f)]
        [Tooltip("The delay time the UI screen will wait before dissapearing")]
        [SerializeField] private float m_UIDelay = 4.0f;
        public float uiDelay
        {
            get
            {
                return this.m_UIDelay;
            }
            set
            {
                this.m_UIDelay = value;
            }
        }


        [Header("From: Components")]
        /// <summary>
        /// TRUE to generate the HTML log
        /// </summary>
        [Tooltip("TRUE to generate the HTML log")]
        [SerializeField] private GameObject m_UIText = null;

        [Tooltip("TRUE to generate the HTML log")]
        [SerializeField] private Transform m_ViewPort = null;




        public VRG_Bhel()
        {
            this.verbose = ENUM_Verbose.ALL;

            this.m_PlayOnEnable = true;
            this.m_NextFrame = false;
            this.m_SelfTurnOff = false;
        }

        /// <summary>
        /// Singleton pattern, Instance is the variable that save the data from every class.
        /// </summary>
        public static VRG_Bhel Instance;
        private void Awake()
        {
            // I will check if I am the first singletong
            if (Instance == null)
            {
                // ... since i am the one, I declare myself as the one
                Instance = this;

                // i follow my own rules
                this.transform.SetParent(null);

                // ... and I will not get destroyed
                DontDestroyOnLoad(this);
            }
            else
            {
                if (Instance != this)
                {
                    // I am not the one... I will walk to the eternal darkness
                    Destroy(this.gameObject);
                }
            }
        }

        public static IEnumerator IsValid() { yield return VRG_Bhel.IsValid(true); }
        public static IEnumerator IsValid(bool valueLocal) { yield return null; }
        public void OpenUrl() { this.Logs("This functionality is available in the full version"); }


        ///#IGNORE
        protected override IEnumerator Do() { yield return null; }
        public static void Do(string valueLocal)
        {
            Do(valueLocal, "", ENUM_Verbose.LOGS, "<font color=red><i>N/A</i></font>");
        }
        public static void Do(string valueLocal, string fromWhereLocal)
        {
            Do(valueLocal, fromWhereLocal, ENUM_Verbose.LOGS, "<font color=red><i>N/A</i></font>");
        }
        public static void Do(string valueLocal, ENUM_Verbose ENUM_VerboseLocal)
        {
            Do(valueLocal, "", ENUM_VerboseLocal, "<font color=red><i>N/A</i></font>");
        }

        /// <summary>
        /// Do the work you are supposed to do, send the message to the console, easy and clean 
        /// </summary>
        /// <param name="valueLocal">The string message to send to the log file</param>
        /// <param name="fromWhereLocal">Helps to understand who summon the log</param>
        /// <param name="ENUM_VerboseLocal">Custom Verbose level, the higher the less likely it will be to be saved</param>
        /// <param name="gameObjectLocal">The object that summons this </param>

//      public static void Do(string valueLocal, string fromWhereLocal, ENUM_Verbose ENUM_VerboseLocal, int iPaddingLocal)
        public static void Do
        (
            string valueLocal,
            string fromWhereLocal,
            ENUM_Verbose ENUM_VerboseLocal,
            string gameObjectLocal
        )
        {
            if (gameObjectLocal.Trim() == string.Empty)
            {
                gameObjectLocal = "<font color=red><i>N/A</i></font>";
            }

            bool bShowInConsole = true;

            string sCr = "\n";

            // if it is not properly inited, do nothing, remember this is a singleton
            if (Instance != null)
            {
                // Solo desplegarlo si pasa el nivel de verbosing
                if (Instance.m_Verbose < ENUM_VerboseLocal)
                {
                    bShowInConsole = false;
                }

                if (ENUM_VerboseLocal <= ENUM_Verbose.WARNING)
                {
                    bShowInConsole = true;
                }

            }
            else
            {
                // Solo desplegarlo si pasa el nivel de verbosing
                if (ENUM_VerboseLocal > ENUM_Verbose.WARNING)
                {
                    bShowInConsole = false;
                }
            }

#if UNITY_EDITOR
            if (bShowInConsole)
            {
                string sColor = VRG.GetEnumColor(ENUM_VerboseLocal);

                string sLogs = ""
                    + "<color=" + sColor + "><b>" + Time.frameCount + ") " + ENUM_VerboseLocal.ToString() + ": </b></color>" + valueLocal + sCr + sCr
                    + "<color=" + sColor + "><b>Class: </b></color>" + fromWhereLocal + sCr
                    + "<color=" + sColor + "><b>Object: </b></color>" + gameObjectLocal + sCr
                    ;

                switch (ENUM_VerboseLocal)
                {
                    default:
                        UnityEngine.Debug.Log(sLogs);
                        break;

                    case ENUM_Verbose.WARNING:
                        UnityEngine.Debug.LogWarning(sLogs);
                        break;

                    case ENUM_Verbose.ERROR:
                        UnityEngine.Debug.LogError(sLogs);
                        break;
                }
            }
#endif

            // if it is not properly inited, do nothing, remember this is a singleton
            if (Instance != null)
            {
                if (Instance.m_UIText != null)
                {
                    if (Instance.m_UIDelay > 0)
                    {
                        // from the random Array of this.m_Prefabs
                        GameObject UiText = Object.Instantiate(Instance.m_UIText, Instance.m_ViewPort.transform);

                        UiText.GetComponent<VRG_Delayed>().SetDelay(Instance.m_UIDelay);

                        UiText.GetComponentInChildren<Text>().text = Time.frameCount + ") ";
                        if (valueLocal == string.Empty)
                        {
                            UiText.GetComponentInChildren<Text>().text += fromWhereLocal;
                        }
                        else
                        {
                            UiText.GetComponentInChildren<Text>().text += valueLocal;
                        }
                    }
                }
            }
        }
    }
}
//*/





/*
// Open the log file to append the new log to it.
this.m_OutputStream = new StreamWriter
(
    string.Format
    (
        "{0} - {1:yyyy-MM-dd H-mm-ss}.html",
        this.m_DirectoryName + "/" + Application.productName,
        DateTime.Now
    ),
    true
);
//*/