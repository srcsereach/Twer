using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public static int countEnemy = 0;
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
        if (EndBlood .blood <= 0)
        {
            StopCoroutine("GenerateEnemy");
            GameManager.Instance.Failure("失败");
        }
    }
    IEnumerator GenerateEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = wave.count; i > 0; i--)
            {
                GameObject.Instantiate(wave.enemy, birthPlace.transform.position, Quaternion.identity);
                Debug.Log(birthPlace.transform.position);
                countEnemy++;
                yield return new WaitForSeconds(wave.span);
            }
            while (countEnemy > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(1);
        }
        while (countEnemy > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win("胜利");
    }


}

