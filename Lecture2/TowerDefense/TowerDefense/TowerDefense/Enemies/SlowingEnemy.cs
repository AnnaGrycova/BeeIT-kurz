using BeeIt.TowerDefense.Enemies;
using BeeIt.TowerDefense.Math;

namespace BeeIt.TowerDefence.Enemies
{
	//====================================================================================================================
	// C. Zpomalující postavička
	//====================================================================================================================
	// 1. Vytvořte třídu 'SlowingEnemy' zděděnou od třídy 'Enemy'
	// 2. V třídě 'Enemy' změňte viditelnost property 'Speed' na 'protected', aby se dala nastavovat i v potomcích
	// 3. Napište funkcionalitu metody 'Hit' tak, aby po každém zásahu se hodnota 'Speed' zmenšila na polovičku
	// 4. Nastavte metodu 'Hit' jako 'override'
	//
	//====================================================================================================================
	// Domácí úkol
	// Změňte kód tak, aby postavička zpomalovala podle určitého vzorce, např. 0.8, 0.7, 0.6, 0.5 apod

    internal class SlowingEnemy : Enemy
    {
        private double deceleration = 0.8;

		public SlowingEnemy(Path path, double speed, int health) : base(path, speed, health)
        {

        }

        public override void Hit(int hitValue)
        {
            Speed *= deceleration;
            if (deceleration > 0) deceleration -= 0.1;
			base.Hit(hitValue);
        }
    }
}