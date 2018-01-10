using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCountDown : MonoBehaviour {

    private LevelManager lm;

    public void SetCountDownNow()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        lm.countDownDone = true;
    }
}
