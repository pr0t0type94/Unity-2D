using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int Repetitions;
        public float timeBetween;
        //public GameObject[] enemy;

        public int lowcount;
        public int midcount;
        public int heavycount;

        public GameObject low;
        public GameObject mid;
        public GameObject heavy;

        
        //public enum SpawnOrder { low, mid, heavy };

    }

    public Wave[] waves;

    private int nextWave = 0;
    public int currentWave = 0;
    //public int totalWaves = 5;

    private float timeBetweenWaves = 0f;
    private float waveCountdown;

    private float startWait = 5f;

    private float searchCounter = 1f;

    public enum SpawnState {spawning,waiting,counting};

    public SpawnState state = SpawnState.counting;


    void Start()
    {
        

        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }
    private void Update()
    {
        if (state == SpawnState.waiting)
        {
            //enemies are still alive
            if (!EnemyIsAlive())
            {
                //begin new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(waveCountdown <=0)
        {
            if(state != SpawnState.spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }


    bool EnemyIsAlive()
    {

        searchCounter -= Time.deltaTime;

        if (searchCounter <= 0)
        {
            searchCounter = 1f;

            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void WaveCompleted()
    {

        state = SpawnState.counting;
        waveCountdown = timeBetweenWaves;

        if(currentWave + 1 > waves.Length-1)
        {

            //SceneManager.LoadScene(1);

            GameManager.instance.WaitStart();

            Debug.Log("completed all waves");
            //nextWave = 0;
            //next level

        }
        else
        {
             nextWave++;
            currentWave++;
        }

    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.spawning;

        
            for (int i = 0; i < _wave.Repetitions; i++)
            {

                for (int x = 0; x < _wave.lowcount; x++)
                {

                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(_wave.low);

                }
                for (int y = 0; y < _wave.midcount; y++)
                {

                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(_wave.mid);
                }
                for (int z = 0; z < _wave.heavycount; z++)
                {

                yield return new WaitForSeconds(0.5f);

                SpawnEnemy(_wave.heavy);
                }
            //for (int x = 0; x < _wave.enemy.Length; x++)
            //{
            //SpawnEnemy(_wave.enemy[x]);
            //}

            yield return new WaitForSeconds(_wave.timeBetween);

            }   
            
        state = SpawnState.waiting;

        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        //Spawn enemy
        Instantiate(_enemy, transform.position, transform.rotation);
    }
}