//Drag into StartNode

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public clas WaceSpawner : MonoBehaviour{
    public Transform enemyPref;

    public Transform spawnPoint;

    public float timeBtwWaves = 10f;
    private float countDown = 10f;

    public Text waveCountDownText;

    private int waveNum = 0;

    void Update(){

        if(countDown<= 0)
        {
           StartCoroutine(SpawnWave());
            countDown = timeBtwWaves;
        }
        countDown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Floor.(countDown + 1).ToString();
    }

   IEnumerator SpawnWave(){
        //if no spawn check this---------------------------
        waveNum = (waveNum*waveNum)-(waveNum*3-2);
   //------------------------------------------------------

        for(int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            //enemy spawn gap
            yield return new WaitForSeconds(0.4f);
        }
        //possible delete*********************
        timeBtwWaves+= 5;
        //----------------------------------
    }
    void SpawnEnemy(){
        Instantiate(enemyPref, spawnPoint.position, spawnPoint.rotation)
}

}