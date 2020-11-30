using UnityEngine;
using System.IO;

[System.Serializable]
public class RewardCar
{
    public int miniCarKey;
    public int buggyKey;
    public int truckKey;
    public int f1CarKey;
    public int sportsCarKey;

    // Start is called before the first frame update
    public void SaveRewards(RewardCar rewards)
    {
        StreamWriter writer;
        string path = Application.persistentDataPath + "/rewarddata.json";
        //string path = Application.dataPath + "/Savedata/rewarddata.json";
        string jsonstr = JsonUtility.ToJson(rewards);

        writer = new StreamWriter(path, false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public RewardCar LoadRewards()
    {
        string datastr = "";
        StreamReader reader;
        string path = Application.persistentDataPath + "/rewarddata.json";
        //string path = Application.dataPath + "/Savedata/rewarddata.json";
        if (!File.Exists(path))
        {
            using (File.Create(path))
            {
            }
            RewardCar rewards = new RewardCar();
            rewards.miniCarKey = 0;
            rewards.buggyKey = 0;
            rewards.truckKey = 0;
            rewards.f1CarKey = 0;
            rewards.sportsCarKey = 0;
            SaveRewards(rewards);
        }
        reader = new StreamReader(path);
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<RewardCar>(datastr);
    }
}
