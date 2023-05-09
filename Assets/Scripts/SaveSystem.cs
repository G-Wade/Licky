using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void SavePlayer(Interactions interactions, PlayerMovementController player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(interactions, player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveFish(Interactions interactions) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/fish.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        FishData data = new FishData(interactions);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.data";
        if(File.Exists(path)) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerData data = formatter.Deserialize(stream) as PlayerData;
        stream.Close();
        
        return data;

        } else {
            return null;
        }
    }

    public static FishData LoadFish() {
        string path = Application.persistentDataPath + "/fish.data";
        if(File.Exists(path)) {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        FishData data = formatter.Deserialize(stream) as FishData;
        stream.Close();
        
        return data;

        } else {
            return null;
        }
    }
}
