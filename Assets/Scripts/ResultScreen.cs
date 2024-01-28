using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ResultScreen : MonoBehaviour
    {
        public Tendency currentTendency;
        public RickTwittSO currentTwitt;
        public int CurrentFollowers { get; private set; }
        public int CurrentReputation { get; private set; }
        private int maxFollowers;

        [SerializeField] private Image arrow;
        [SerializeField] private Sprite arrowUp;
        [SerializeField] private Sprite arrowDown;
        [SerializeField] private TextMeshProUGUI followersNumber;
        private UnityEvent onResultScreenShow;

        public void CheckResults()
        {
            var previousRep = CurrentReputation;
            var previousFollowers = CurrentFollowers;
            CheckTwitts(currentTendency.relatedTweets);
            CurrentReputation += currentTwitt.repPoints;
            CurrentFollowers += currentTwitt.followPoints;
            CheckTwitts(currentTwitt.posibleTwitts);
            arrow.sprite = previousRep <= CurrentReputation ? arrowUp : arrowDown;
            var letter = CurrentFollowers >= maxFollowers ? "M" : "K";
            var follownumber = $"{CurrentFollowers}{letter}";
            followersNumber.text = follownumber;
            onResultScreenShow.Invoke();
        }

        public void SetFollowersRep(int CurrentFollowers, int CurrentReputation, int MaxFollowers)
        {
            this.CurrentFollowers = CurrentFollowers;
            this.CurrentReputation = CurrentReputation;
            maxFollowers = MaxFollowers;
        }

        private void CheckTwitts(List<TwittSO> list)
        {
            foreach (var twitt in list)
            {
                if (twitt.isLiked)
                {
                    CurrentFollowers += twitt.followPoints;
                }

                if (twitt.isRetwitted)
                {
                    CurrentReputation += twitt.repPoints;
                }
            }
        }
    }
}