using BreakInfinity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public BigDouble cw;
    public int production;
    public int numberOfCups;
    public int numberOfBreifs;
    public int numberOfCars;
    public int numberOfKims;
    public int numberOfWalts;
    public int numberOfLalos;
    public float sensitivity;

    public GameData()
    {
        this.cw = 0;
        this.production = 0;
        this.numberOfCups = 0;
        this.numberOfBreifs = 0;
        this.numberOfCars = 0;
        this.numberOfKims = 0;
        this.numberOfWalts = 0;
        this.numberOfLalos = 0;
        this.sensitivity = 0;
    }

}
