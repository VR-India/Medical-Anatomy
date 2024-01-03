using UnityEditor;

namespace Inucom
{   
    public class CoreScriptTemplate
    {
       [MenuItem("Assets/Create/Script/MonoBehaviour", priority =40)]
        public static void CreateMonoBehaviourMenuItem()
        {
            string templatePath = "Assets/Editor/Templates/MonoBehaviour.cs.txt";
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewBehaviour.cs");
        }

        [MenuItem("Assets/Create/Script/Enum", priority = 41)]
        public static void CreateEnumMenuItem()
        {
            string templatePath = "Assets/Editor/Templates/Enum.cs.txt";
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewEnum.cs");
        }

        [MenuItem("Assets/Create/Script/Scriptable", priority = 42)]
        public static void CreateScriptableMenuItem()
        {
            string templatePath = "Assets/Editor/Templates/Scriptable.cs.txt";
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewScriptable.cs");
        }

        [MenuItem("Assets/Create/Script/Class", priority = 43)]
        public static void CreateClassMenuItem()
        {
            string templatePath = "Assets/Editor/Templates/Class.cs.txt";
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewClass.cs");
        }
    }
}