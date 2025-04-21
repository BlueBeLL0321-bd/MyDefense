using UnityEngine;

namespace Solid_Interface
{
    // 스탯을 가진 유닛
    public interface IStats
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }
}