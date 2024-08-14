/*
/*/
using UnityEditor;
using UnityEngine;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_BHEL : VRG_Editor_Menu
    {
        public new static string m_Prefabs = "Tools/BHEL/Prefabs/";

        public new static void menuFSM(int indexLocal, string pathLocal)
        {
            switch (pathLocal)
            {
                // BHEL/
                case m_2:
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
            VRG_WindowBHEL window = (VRG_WindowBHEL)EditorWindow.GetWindow(typeof(VRG_WindowBHEL), false, "Download BHEL from Asset Store", true);

            window.maxSize = new Vector2(525f, 580f);
            window.minSize = window.maxSize;

            window.Show();
        }

        public class VRG_WindowBHEL : EditorWindow
        {

            private GUIStyle m_StyleWrap;
            private static Texture2D m_Logo;
            private static float m_Width;
            private static float m_Height;

            void Awake()
            {
                m_Logo = (Texture2D)AssetDatabase.LoadAssetAtPath(VRG_Editor.CalculateInstallationPath() + "Tools/BHEL/Sprites/BHEL_AssetStore.png", typeof(Texture2D));

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

                GUILayout.Label("B.H.E.L is a plugin that allows you to configure your application to have an external log to debug your game, you can also see the logs into the Screen as a floating UI, or in CSV format for later analysis. These components are already pre-configured and ready to use them out of the box.", this.m_StyleWrap);

                EditorGUILayout.Space();
                EditorGUILayout.Space();

                GUILayout.Label("Fixing and debugging code has many issues, specially if you program using asynchrony operations, you can save all your work in a nice html file so you can review and fix it from your web browser.", this.m_StyleWrap);

                EditorGUILayout.Space();
                EditorGUILayout.Space();



                GUI.DrawTexture(new Rect(35, 175, (m_Width / 1.70f), (m_Height / 1.70f)), m_Logo);

                GUILayout.FlexibleSpace();
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("Open Unity Asset Store         ", GUILayout.Width(570), GUILayout.Height(45)))
                {
                    this.Close();

                    VRG.OpenUrl("https://u3d.as/2i6n");
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();

            }
        }
    }
}
//*/