using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutsceneend : MonoBehaviour
{
    public void OnCutsceneComplete()
    {
        SceneManager.LoadScene("Noah Scene");
    }

}
