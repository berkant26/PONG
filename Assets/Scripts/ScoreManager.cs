using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _playerScore;
    private int _opponentScore;
    private List<IScoreObserver> _observers = new List<IScoreObserver>();

    public int PlayerScore => _playerScore;
    public int OpponentScore => _opponentScore;

    public void AddObserver(IScoreObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void RemoveObserver(IScoreObserver observer)
    {
        _observers.Remove(observer);
    }

    public void AddPlayerScore()
    {
        _playerScore++;
        NotifyObservers();
    }

    public void AddOpponentScore()
    {
        _opponentScore++;
        NotifyObservers();
    }

    public void ResetScores()
    {
        _playerScore = 0;
        _opponentScore = 0;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.onScoreChanged(_playerScore, _opponentScore);
        }
    }
}
