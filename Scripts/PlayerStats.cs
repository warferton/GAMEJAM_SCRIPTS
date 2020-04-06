using UnityEngine;
using System.Collection;

public class PlayerStats : MonoBehaviour{
    public static int money;
    public int startMoney;

    void Start()
    {
        money = startMoney;
    }
}