using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Towerdefense
{
    public class WaveUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _waveCountText;
        private void OnEnable()
        {
            WaveSO.onCountChange += UpdateWaveText;
        }
        private void OnDisable()
        {
            WaveSO.onCountChange -= UpdateWaveText;
        }
        private void UpdateWaveText(int waveCount,int waveMax)
        {
            _waveCountText.text = $"{waveCount} / {waveMax}";
        }
    }
}
