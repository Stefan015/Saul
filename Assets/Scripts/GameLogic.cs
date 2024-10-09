using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.Events;
using UnityEngine.UIElements;
using static GameLogic;
using TMPro;
using BreakInfinity;
using Unity.VisualScripting;




public class GameLogic : MonoBehaviour, IDataPersistance
{
    private BigDouble cw = 0;
    private int production = 0;
    private int numberOfCups = 0;
    private int numberOfBreifs = 0;
    private int numberOfCars = 0;
    private int numberOfKims = 0;
    private int numberOfWalts = 0;
    private int numberOfLalos = 0;

    public TextMeshProUGUI uiCwShow;
    public TextMeshProUGUI textDisplayCW;
    public TextMeshProUGUI textDisplayProdu;
    public TextMeshProUGUI cupsText;
    public TextMeshProUGUI breifsText;
    public TextMeshProUGUI carsText;
    public TextMeshProUGUI kimsText;
    public TextMeshProUGUI waltsText;
    public TextMeshProUGUI lalosText;

    private void Start()
    { 
        updateText();
        StartCoroutine(IncrementCW());
    }
    void Update()
    {
        uiCwShow.text = "CW = " + cw;
        textDisplayCW.text = "CW = " + cw;
        textDisplayProdu.text = "Production = " + production + "cw/s";
    }

    void addPoint()
    {
        cw++;        
    }
    void OnEnable()
    {
        EventManager.Instance.OnEventClick += HandleClick;
        EventManager.Instance.OnEvent10 += Handle10;
        EventManager.Instance.OnEvent100 += Handle100;
        EventManager.Instance.OnEvent1k += Handle1k;
        EventManager.Instance.OnEvent10k += Handle10k;
        EventManager.Instance.OnEvent100k += Handle100k;
        EventManager.Instance.OnEvent1m += Handle1m;
    }

    void OnDisable()
    {
        EventManager.Instance.OnEventClick -= HandleClick;
        EventManager.Instance.OnEvent10 -= Handle10;
        EventManager.Instance.OnEvent100 -= Handle100;
        EventManager.Instance.OnEvent1k -= Handle1k;
        EventManager.Instance.OnEvent10k -= Handle10k;
        EventManager.Instance.OnEvent100k -= Handle100k;
        EventManager.Instance.OnEvent1m -= Handle1m;
    }

    void HandleClick()
    {
        cw++;
    }
    void Handle10()
    {
        if (cw >= 10) { production += 1; cw -= 10; numberOfCups++; updateText(); }
    }
    void Handle100()
    {
        if (cw >= 100) { production += 10; cw -= 100; numberOfBreifs++; updateText(); }
    }
    void Handle1k()
    {
        if (cw >= 1000) { production += 100; cw -= 1000; numberOfCars++; updateText(); }       
    }
    void Handle10k()
    {
        if (cw >= 10000) { production += 1000; cw -= 10000; numberOfKims++; updateText(); }
    }    
    void Handle100k()
    {
        if (cw >= 100000) { production += 10000; cw -= 100000; numberOfWalts++; updateText(); }
    }
    void Handle1m()
    {
        if (cw >= 1000000) { production += 100000; cw -= 100000; numberOfLalos++; updateText(); }
    }

    void updateText()
    {
        cupsText.text = numberOfCups.ToString();
        breifsText.text = numberOfBreifs.ToString();
        carsText.text = numberOfCars.ToString();
        kimsText.text = numberOfKims.ToString();
        waltsText.text = numberOfWalts.ToString();
        lalosText.text = numberOfLalos.ToString();
    }
    IEnumerator IncrementCW()
    {
        while (true)
        {
            cw += production;
            yield return new WaitForSeconds(1f);
        }
    }

    public void LoadData(GameData data)
    {
        cw = data.cw;
        production = data.production;
        numberOfCups = data.numberOfCups;
        numberOfBreifs = data.numberOfBreifs;
        numberOfCars = data.numberOfCars;
        numberOfKims = data.numberOfKims;
        numberOfWalts = data.numberOfWalts;
        numberOfLalos = data.numberOfLalos;
    }

    public void SaveData(ref GameData data)
    {
        data.cw = cw;
        data.production = production;
        data.numberOfCups = numberOfCups;
        data.numberOfBreifs = numberOfBreifs;
        data.numberOfCars = numberOfCars;
        data.numberOfKims = numberOfKims;
        data.numberOfWalts = numberOfWalts;
        data.numberOfLalos = numberOfLalos;
    }
    public void resetProgress()
    {
        cw = 0;
        production = 0;
        numberOfCups = 0;
        numberOfBreifs = 0;
        numberOfCars = 0;
        numberOfKims = 0;
        numberOfWalts = 0;
        numberOfLalos = 0;
        updateText();
    }
}
