using System.Runtime.CompilerServices;
using BeeIt.TowerDefense.Enemies;
using BeeIt.TowerDefense.Math;

namespace BeeIt.TowerDefence.Enemies
{
	//====================================================================================================================
	// E. Zastavující se postavička
	//====================================================================================================================
	// 1. Vytvořte třídu 'StoppingEnemy' zděděnou od třídy 'Enemy'
	// 2. Vytvořte field '_sleep' typu 'int', který si bude pamatovat, jak dlouho je ještě třeba se nepohybovat
	// 3. Vytvořte field '_defaultSpeed' typu 'double', abychom si zapamatovali výchozí rychlost
	// 4. Napište funkcionalitu metody 'Hit' tak, aby po každém zásahu se hodnota 'Speed' nastavila na 0 a '_sleep' na 20
	// 5. Napište funkcionalitu metody 'Move' tak, aby se chovala následnovně:
	//    a. Pokud je hodnota '_sleep' větší než 0, tak odečti od něj 1
	//    b. Pokud je hodnota '_sleep' rovna 0, zkopíruj hodnotu '_defaultSpeed' do 'Speed'
	//    c. Zavolej bázovou třídu 'Enemy'
	//
	//====================================================================================================================
	// Domácí úkol
	// Změňte kód tak, aby postavička se zastavila úplně po zásahu, ale postupně nabírala rychlost až na hodnotu '_defaultSpeed'
    //pridat acceleration

    internal class StoppingEnemy : Enemy
    {
        private bool _hitted;
        private int _sleep;
        private double _defaultSpeed;
        private const int DEFAULT_SLEEP = 20; //dobre je nastavit defaultni hodnotu jako konstantu
        private const double DEFAULT_ACCELERATION = 0.1;

        public StoppingEnemy(Path path, double speed, int health) : base(path, speed, health)
        {
            _sleep = 0;
            _defaultSpeed = speed;
            _hitted = false;
        }

        public override void Move()
        {
            if (_sleep > 0) _sleep--;
            if (_hitted)
            {
                if (Speed < _defaultSpeed)
                {
                    Speed += _defaultSpeed * DEFAULT_ACCELERATION;
                }
                else
                {
                    _hitted = false;
                }
            }

            base.Move();
        }

        public override void Hit(int hitValue)
        {
            Speed = 0;
            _sleep = DEFAULT_SLEEP;
            _hitted = true;
            base.Hit(hitValue);
        }
    }
}