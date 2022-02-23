using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    private static string path;

    public void Awake()
    {
        path = Application.dataPath + "\\Data\\";
    }

    public class Save
    {
        public static string Path { get => path; }

        public static void SaveData(string file_name, params Object[] obj)
        {
            FileStream f_stream = File.Open(path + file_name, FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(f_stream);

            foreach(Object o in obj)
                writer.WriteLine(EditorJsonUtility.ToJson(o));

            writer.Flush();
            writer.Close();
        }
    }

    public static void ClearDirectory()
    {
        DirectoryInfo di = new DirectoryInfo(path);

        foreach (FileInfo file in di.GetFiles())
            file.Delete();
    }

    public class Load
    {
        public static void LoadData(string file_name, params Object[] obj)
        {
            FileStream f_stream = File.OpenRead(path + file_name);
            StreamReader reader = new StreamReader(f_stream);

            string temp = null;
            for (int i = 0; i < obj.Length; i++)
            {
                temp = reader.ReadLine();
                if (temp == null)
                    break;

                EditorJsonUtility.FromJsonOverwrite(temp, obj[i]);
            }

            reader.Close();
        }
        public static void LoadGameObjects(string file_name)
        {
            FileStream f_stream = File.OpenRead(path + file_name);
            StreamReader reader = new StreamReader(f_stream);

            string temp = reader.ReadLine();
            do
            {
                GameObject m = (GameObject)EditorJsonUtility.FromJsonOverwrite(temp);

                Instantiate(m);

                temp = reader.ReadLine();

            } while (temp != null);

            reader.Close();
        }
    }
}