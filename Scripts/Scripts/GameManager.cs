using UinityEngine; 
using System.Collection; 

public class GameManager : MonoBehaviour{

    private bool gameEnded = flase;

    void Update(){
        if(gameEnded){
             return;}

        if(PlayerStats.Lives < 0)
        {
            EndGame();
        }
    }

    void EndGame(){
        Debug.Log("GG!");
        gameEnded = true;

    }
}