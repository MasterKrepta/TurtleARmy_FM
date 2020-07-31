using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

//TODO Do we need this class at all? it looks like i am not using it anymore
//  public class PlayerDataManager : MonoBehaviour
//{

//    public Minion Player;
//    public Money Money;
//    public GameObject[] Minions;

//    public Text[] TestUis;
    
//    #region Singleton
//    public static PlayerDataManager Instance;

//        private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        DontDestroyOnLoad(this);
        
//        UpdateTestUI();
//    }
//    #endregion


//    public void SaveData()
//    {
//        BinaryFormatter formatter = new BinaryFormatter();
//        string path = Application.persistentDataPath + "/player.stats";
//        FileStream stream = new FileStream(path, FileMode.Create);



//        //todo Assign current player data

//        formatter.Serialize(stream, Player);
//        stream.Close();
//    }

//    public  void LoadData()
//    {
//        string path = Application.persistentDataPath + "/player.stats";
//        if (File.Exists(path))
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            FileStream stream = new FileStream(path, FileMode.Open);
            
//            Player =  formatter.Deserialize(stream) as Minion;
//            stream.Close();
//            //todo Assign current player data
//            UpdateTestUI();

//        }
//        else
//        {
//            Debug.LogError($"Save file not found in {path}");
//            UpdateTestUI();
//        }
        
//    }
    
//    void SaveMinionData()
//    {
//        foreach (var m in Minions)
//        {
//            //todo Assign Minion Data to data object and save;
//        }
//    }

//    void UpdateTestUI()
//    {
//        TestUis[0].text = $"Health: {Player.Health.ToString()}";
//        TestUis[1].text = $"Speed: {Player.MoveSpeed.ToString()}";
//        TestUis[2].text = $"Delay: {Player.AttackDelay.ToString()}";
//        TestUis[3].text = $"Power: {Player.AttackPower.ToString()}";
//        TestUis[4].text = $"Money: {Money.CurrentMoney.ToString()}";
//    }

//    public void ResetDataToDefaults()
//    {
//        Player.Health = Player.Starting_Health;
//        Player.MoveSpeed = Player.Starting_MoveSpeed;
//        Player.AttackDelay = Player.Starting_AttackDelay;
//        Player.AttackPower = Player.Starting_AttackPower;
//        Money.CurrentMoney = Money.StartingMoney;

//        UpdateTestUI();
//    }
//}
