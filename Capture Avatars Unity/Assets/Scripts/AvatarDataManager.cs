using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class AvatarDataManager : MonoBehaviour
{
    public static AvatarDataManager Instance;
    public AvatarData activeAvatarData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("hasOpenedApp") == 1)
        {
            Load();
        }
        else
        {
            PlayerPrefs.SetInt("hasOpenedApp", 1);
        }
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        UserData userData = new UserData();
        userData.avatarData = activeAvatarData;

        binaryFormatter.Serialize(file, userData);
        file.Close();

        string json = JsonUtility.ToJson(activeAvatarData);
        print(json);

        DebugConsole.Instance.ShowMessage("Saved: \n" + json);
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            UserData data = (UserData)binaryFormatter.Deserialize(file);
            file.Close();

            activeAvatarData = data.avatarData;

            string json = JsonUtility.ToJson(activeAvatarData);
            print(json);

            DebugConsole.Instance.ShowMessage("Loaded: \n" + json);
        }
    }
}

[System.Serializable]
class UserData
{
    public AvatarData avatarData;
}
