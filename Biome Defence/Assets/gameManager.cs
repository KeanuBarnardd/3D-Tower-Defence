using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

    public bool gameIsOver = false;

    // Update is called once per frame
    void Update() {
        if (PlayerStats.Lives <= 0)
        {
            PlayerStats.Lives = 0;
            EndGame();
        }
	}

    void EndGame() {

        if (gameIsOver == false) {
            Debug.Log("<color=red> Game Over !</color>");
            gameIsOver = true;
        }
      
    }
}
