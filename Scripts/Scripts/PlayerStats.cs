using UnityEngine;
using System.Collection;

public class PlayerStats : MonoBehaviour{
    public static int money;
    public int startMoney;

    public static int Lives;
    public int startLives = 10;

    void Start()
    {
        money = startMoney;
        Lives = startLives;
    }
} 