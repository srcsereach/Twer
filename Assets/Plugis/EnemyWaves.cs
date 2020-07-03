using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public static int countEnemy=0;
    public Wave[] waves;
    public GameObject birthPlace;

    // Start is called before the first frame update
    void Start()
    {
      
        StartCoroutine("GenerateEnemy");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GenerateEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = wave.count; i > 0; i--)
            {
                GameObject.Instantiate(wave.enemy, birthPlace.transform.position,Quaternion.identity);
                countEnemy++;
                yield return new WaitForSeconds(wave.span);
            }
            while (countEnemy > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
