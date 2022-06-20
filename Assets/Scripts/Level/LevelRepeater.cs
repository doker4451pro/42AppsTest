using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRepeater : MonoBehaviour
{
    [SerializeField, Range(0, 5)] private float _timeToReadTextOnEndLevel;

    public void RepeatLevel()
    {
        StartCoroutine(RepeatLevelCoroutine());
    }

    private IEnumerator RepeatLevelCoroutine()
    {
        float time = 0;
        while (time < _timeToReadTextOnEndLevel)
        {
            time += Time.deltaTime;
            yield return null;
        }

        var loadLevelAsync = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        while (!loadLevelAsync.isDone)
        {
            yield return null;
        }
    }
}
