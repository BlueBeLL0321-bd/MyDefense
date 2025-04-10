using UnityEngine;
using TMPro;

namespace MyDefense
{
    public class PlayerBaseLifeUI : MonoBehaviour
    {
        #region Field
        // Life Text
        public TextMeshProUGUI livesText;
        #endregion
        
        // Update is called once per frame
        void Update()
        {
            livesText.text = PlayerStats.Lives.ToString();
        }
    }
}