using UnityEngine;

using UnityEditor;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_AboutUs : VRG_Editor_Menu
    {
        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (indexLocal)
            {
                // About/Installation path
                case p_6_1:
                    print("The installation path of Vr Games Dev Packages is: " + CalculateInstallationPath());
                break;

                //  About/Us and this software
                case p_6_2:                
                    // Get existing open window or if none, make a new one:
                    VRG_WindowStatus window = (VRG_WindowStatus)EditorWindow.GetWindow(typeof(VRG_WindowStatus), false, "About VrGamesDev");

                    window.maxSize = new Vector2(500f, 500f);
                    window.minSize = window.maxSize;

                    window.Show();
                break;
                
                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                break;
            }
        }

        public class VRG_WindowStatus : EditorWindow
        {
            private static float m_Width;
            private static float m_Height;
            private static Texture2D m_Logo;
            private static GUIStyle m_StyleWrap;
            private static GUIStyle m_StylePadding;
            private static GUIStyle m_StyleLink;

            void Awake()
            {
                m_Logo = (Texture2D)AssetDatabase.LoadAssetAtPath(VRG_Editor.CalculateInstallationPath() + "Tools/CORE/Sprites/VrGamesDev.png", typeof(Texture2D));

                m_Width = 1200.0f;
                m_Height = 800.0f;

                position = new Rect(0, 00, 325, 500);
            }


            void OnGUI()
            {
                m_StyleWrap = new GUIStyle(GUI.skin.label);
                m_StyleWrap.wordWrap = true;

                m_StylePadding = new GUIStyle(GUI.skin.label);
                m_StylePadding.padding = new RectOffset(0, 0, 150, 0);

                m_StyleLink = new GUIStyle(EditorStyles.label);
                m_StyleLink.normal.textColor = new Color(0x00 / 255f, 0x78 / 255f, 0xDA / 255f, 1f);
                m_StyleLink.stretchWidth = false;


                GUI.DrawTexture(new Rect((this.position.width / 2) - (m_Width / 12), 10, (m_Width / 6), (m_Height / 6)), m_Logo);

                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("... because the future is in VR", m_StylePadding);

                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("We are a couple that make games since 1996, we have made 20+ games, currently creating a mobile Idle RPG, and a Virtual Reality FPS exploration, we love games, technology and to improve and enhance tools. \nFeel free to talk with us about anything, and enjoy our assets.", m_StyleWrap);

                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("Support: ", m_StyleWrap);
                if (GUILayout.Button("unity.support@vrgamesdev.com", m_StyleLink))
                {
                    Application.OpenURL("mailto:unity.support@vrgamesdev.com");
                }
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("Website: ", m_StyleWrap);
                if (GUILayout.Button("https://www.vrgamesdev.com", m_StyleLink))
                {
                    Application.OpenURL("https://www.vrgamesdev.com");
                }
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("Enjoy our other assets from the asset store.", m_StyleWrap);
                if (GUILayout.Button("https://assetstore.unity.com/publishers/49114", m_StyleLink))
                {
                    Application.OpenURL("https://assetstore.unity.com/publishers/49114");
                }
                GUILayout.FlexibleSpace();
            }
        }

    }
}