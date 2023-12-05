using UnityEditor;

namespace iNucom
{
    public class CreateScriptTemplates
    {
        [MenuItem("Assets/Create/Code/MonoBehaviour", priority=40)]
        public static void CreateMonoBehaviourMenuItem()
        {
            string templatePath = "Assets/Scripts/Editor/Template/MonoBehaviour.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScript.cs");
        }

        [MenuItem("Assets/Create/Code/Enum", priority = 41)]
        public static void CreateEnumMenuItem()
        {
            string templatePath = "Assets/Scripts/Editor/Template/Enum.cs.txt"; 

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEnum.cs");
        }
        [MenuItem("Assets/Create/Code/Scriptable", priority = 41)]
        public static void CreateScriptableMenuItem()
        {
            string templatePath = "Assets/Scripts/Editor/Template/ScriptableObject.cs.txt";

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScriptable.cs");
        }
    }
}
