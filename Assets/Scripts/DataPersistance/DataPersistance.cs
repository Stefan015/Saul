using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistance : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    private List<IDataPersistance> dataPersitanceObjects;

    private FileDataHandler fileDataHandler;
    public static DataPersistance instance { get; private set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one DPmanager in scene");
        }
        instance = this;
    }
    private void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath,fileName);
        this.dataPersitanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    } 
    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("no data was found. creating one with defaults ");
            NewGame();
        }
        foreach(IDataPersistance dataPersistanceObj in dataPersitanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    } 
    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersitanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        fileDataHandler.Save(gameData);
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
