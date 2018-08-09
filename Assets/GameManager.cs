using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BluePhoenix
{
    public class GameManager : MonoBehaviour
    {

        [Range(0.1f, 5f)]
        public float startDelay;

        public GameObject fightSign;

        [Range(0.1f, 5f)]
        public float maxFightDelay;

        bool started;

        bool waiting;

        float clickTime;
        float fightTime;

        enum GameState
        {
            Idle,
            Started,
            Ended
        }

        GameState gameState = GameState.Idle;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(gameState == GameState.Idle)
            {
                if(Input.anyKeyDown)
                {
                    gameState = GameState.Started;
                    StartCoroutine(Fight(Random.Range(0.1f, maxFightDelay)));
                }
            }
        }

        IEnumerator Fight(float delay)
        {
            yield return new WaitForSeconds(delay);
            fightSign.SetActive(true);
        }
    }
}
