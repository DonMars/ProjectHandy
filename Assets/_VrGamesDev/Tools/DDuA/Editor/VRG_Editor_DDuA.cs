/*
/*/
using UnityEngine;

using UnityEditor;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_DDuA : VRG_Editor_Menu
    {
        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (indexLocal)
            {
                // DDUA
                case p_3:
                    PopUp();
                break;

                default:
                    VRG_Editor_Menu.menuFSM(indexLocal, pathLocal);
                break;
            }
        }

        // Get existing open window or if none, make a new one:
        public static void PopUp()
        {
            VRG_WindowDDuA window = (VRG_WindowDDuA)EditorWindow.GetWindow(typeof(VRG_WindowDDuA), false, "Download DDuA from Asset Store", true);

            window.maxSize = new Vector2(525f, 580f);
            
            window.minSize = window.maxSize;

            window.Show();
        }

        public class VRG_WindowDDuA : EditorWindow
        {
            private GUIStyle m_StyleWrap;
            private static Texture2D m_Logo;
            private static float m_Width;
            private static float m_Height;

            void Awake()
            {
                m_Logo = (Texture2D)AssetDatabase.LoadAssetAtPath(VRG_Editor.CalculateInstallationPath() + "Tools/DDuA/Sprites/DDUA_AssetStore.png", typeof(Texture2D));

                m_Width = 775.0f;
                m_Height = 550.0f;
            }

            void OnGUI()
            {
                this.m_StyleWrap = new GUIStyle(GUI.skin.label);
                this.m_StyleWrap.wordWrap = true;

                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("Sometimes Unity Addressables can be cumbersome. However, you'll be able to forget about the complexity of implementing this solid and powerful technology. Save yourself hundred of hours and headaches!", this.m_StyleWrap);

                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("DDuA is a package that allows you to create games and applications using the Addressables system. It is perfect to help developers to create rich complex games  with frequent content updates delivery needs, clean, fast and smart.", this.m_StyleWrap);

                EditorGUILayout.Space();
                EditorGUILayout.Space();


                GUI.DrawTexture(new Rect(35, 175, (m_Width / 1.70f), (m_Height / 1.70f)), m_Logo);

                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Open Unity Asset Store         ", GUILayout.Width(570), GUILayout.Height(45)))
                {
                    this.Close();

                    VRG.OpenUrl("https://u3d.as/1Xtd");
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();

            }
        }
    }
}
//*/