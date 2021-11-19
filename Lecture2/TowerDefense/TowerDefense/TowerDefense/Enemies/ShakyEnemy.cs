using System;
using BeeIt.TowerDefense.Enemies;
using BeeIt.TowerDefense.Math;

namespace BeeIt.TowerDefence.Enemies
{
	//====================================================================================================================
	// D. Třesoucí se postavička
	//====================================================================================================================
	// 1. Vytvořte třídu 'ShakyEnemy' zděděnou od třídy 'Enemy'
	// 2. Přidejte do třídy field '_random' typu 'Random'
	// 3. Field '_random' inicializujte v konstruktoru jako: _random = new Random(DateTime.UtcNow.Millisecond);
	// 4. Přidejte metodu pro výpočet třesoucího vektoru:
	// private Vector GetShakyVector()
	// {
	//   var x = (_random.NextDouble() - 0.5) * 0.1;
	//   var y = (_random.NextDouble() - 0.5) * 0.1;
	//   return new Vector(x, y);
	// }
	// 5. V třídě 'Enemy' změňte viditelnost property 'Position' na 'protected', aby se dala nastavovat i v potomcích
	// 6. Změňte funkcionalitu metody 'Hit' tak, aby k property 'Position' přidala výstup z metody 'GetShakyVector'
	//
	//====================================================================================================================
	// Domácí úkol
	// Změňte kód tak, aby se postavička začla třást až po prvním zásahu
    internal class ShakyEnemy : Enemy
    {
        private Random _random;
        private bool _hitted;
        //public bool Hitted { get; private set; } ==> redundantni
        public ShakyEnemy(Path path, double speed, int health) : base(path, speed, health)
        {
            _random = new Random(DateTime.UtcNow.Millisecond);
            _hitted = false;
        }
		public override void Move()
        {
            if (_hitted)
            {
                Position += GetShakyVector();
            }
            base.Move();
        }

        public override void Hit(int hitValue)
        {
            _hitted = true;
			base.Hit(hitValue);
			//base.Move(); "poruseni kontraktu"
        }

        private Vector GetShakyVector()
        {
            var x = (_random.NextDouble() - 0.5) * 0.1;
            var y = (_random.NextDouble() - 0.5) * 0.1;
            return new Vector(x, y);
        }
    }
}