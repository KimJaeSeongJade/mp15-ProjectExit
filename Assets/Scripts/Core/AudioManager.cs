using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioPlayer _audioPlayerPrefab;
    [SerializeField] private int _poolSize;

    private Stack<AudioPlayer> _audioPlayers;
    public bool IsInitCompleted { get; private set; }

    private void Awake()
    {
        SetSingleton();
        InitPool();
    }

    public AudioPlayer TakeAudioPlayer()
    {
        if (!IsInitCompleted)
        {
            Debug.LogError($"{gameObject.name} : Audio Pool이 초기화 되지 않았음");
            return null;
        }
        
        AudioPlayer player;
        
        if(_audioPlayers.Count == 0) player = CreateAudioPlayer();
        else player = _audioPlayers.Pop();

        player.gameObject.SetActive(true);

        return player;
    }

    private void InitPool()
    {
        _audioPlayers = new Stack<AudioPlayer>(_poolSize);
        
        while (_audioPlayers.Count < _poolSize)
        {
            _audioPlayers.Push(CreateAudioPlayer());
        }
        
        IsInitCompleted = true;
    }

    private AudioPlayer CreateAudioPlayer()
    {
        AudioPlayer player = Instantiate(_audioPlayerPrefab);
        player.transform.SetParent(transform);
        player.gameObject.SetActive(false);
        return player;
    }

    public void Return(AudioPlayer player)
    {
        _audioPlayers.Push(player);
        player.gameObject.SetActive(false);
    }
}
