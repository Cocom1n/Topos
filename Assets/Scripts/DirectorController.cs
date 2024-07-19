using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DirectorController : MonoBehaviour
{
    [SerializeField] private PlayableDirector playableDirector;
    [SerializeField] private Canvas hud;

    private void Start()
    {
        hud.enabled = false;
        playableDirector.stopped += OnPlayableDirectorStopped;
    }

    void Update()
    {
        if (GameManager.Instance.eventoAraña == true)
        {
            Destroy(gameObject);
        }
    }

    void OnPlayableDirectorStopped(PlayableDirector director)
    {
        hud.enabled = true;
    }
}
