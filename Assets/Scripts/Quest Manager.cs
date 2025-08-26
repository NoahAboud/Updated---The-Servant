using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public List<QuestProgress> currentQuests = new List<QuestProgress>();
    public List<QuestProgress> completeQuests = new List<QuestProgress>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance)
                Destroy(gameObject);
        }
    }

}

[System.Serializable]

public class QuestProgress
{
    public QuestProgress data;
    public List<QuestProgress> tasks = new List<QuestProgress>();
}
