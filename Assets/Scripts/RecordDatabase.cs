using UnityEngine;
using System.IO;

[System.Serializable]
public class Record
{
    public float JSMfirst;
    public float JSMsecond;
    public float JSMthird;

    public float TAMfirst;
    public float TAMsecond;
    public float TAMthird;

    //public void JSMInitialize()
    //{
    //    Record JSMRecords = new Record();
    //    JSMRecords.JSMfirst = 999;
    //    JSMRecords.JSMsecond = 999;
    //    JSMRecords.JSMthird = 999;
    //    SaveRecords(JSMRecords);
    //}

    //public void TAMInitialize()
    //{
    //    Record TAMRecords = new Record();
    //    TAMRecords.TAMfirst = 0;
    //    TAMRecords.TAMsecond = 0;
    //    TAMRecords.TAMthird = 0;
    //    SaveRecords(TAMRecords);
    //}

    public void SaveRecords(Record records)
    {
        StreamWriter writer;
        string path = Application.persistentDataPath + "/savedata.json";
        string jsonstr = JsonUtility.ToJson(records);

        writer = new StreamWriter(path, false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public Record LoadRecords()
    {
        string datastr = "";
        StreamReader reader;
        string path = Application.persistentDataPath + "/savedata.json";
        if (!File.Exists(path))
        {
            using (File.Create(path))
            {
            }
            Record records = new Record();
            records.JSMfirst = 999;
            records.JSMsecond = 999;
            records.JSMthird = 999;
            records.TAMfirst = 0;
            records.TAMsecond = 0;
            records.TAMthird = 0;
            SaveRecords(records);
        }
        reader = new StreamReader(path);
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Record>(datastr);
    }
}

