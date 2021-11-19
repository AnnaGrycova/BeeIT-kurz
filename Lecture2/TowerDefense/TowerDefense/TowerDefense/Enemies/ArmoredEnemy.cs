using System;
using BeeIt.TowerDefense.Math;

namespace BeeIt.TowerDefense.Enemies
{
	//====================================================================================================================
	// B. Postavička s brněním
	//====================================================================================================================
	// 1. Vytvořte třídu 'ArmoredEnemy' zděděnou od třídy 'Enemy'
	// 2. V konstruktoru předejte hodnotu k inicializaci brnění 'Armor'
	// 3. Přidejte do třídy property 'Armor' typu int deklarující stav brnění
	// 4. Změňte funkcionalitu metody 'Hit' tak, aby bylo zasaženo nejdřív brnění 'Armor' a pak jeho životy
	// 5. V třídě 'Enemy' nastavte metodu 'Hit' na 'virtual', aby ji bylo možné přepsat v potomcích
	// 6. V této tříde nastavte metodu 'Hit' na 'override', abychom ji v potomkovi přepsali
	//
	//====================================================================================================================
	// Domácí úkol
	// Změňte kód tak, aby postavička ubírala život brnění a sobě na přeskáčku

    internal class ArmoredEnemy : Enemy
    {
        private bool _lastDamageOnArmor;
        public int Armor { get; private set; }

        public ArmoredEnemy(Path path, double speed, int health, int armor) : base(path, speed, health)
        {
            Armor = armor;
            _lastDamageOnArmor = false;
        }

        public override void Hit(int hitValue)
        {
            if (Armor > 0 && !_lastDamageOnArmor)
            {
                Armor -= hitValue;
                _lastDamageOnArmor = true;
            }
            else
            {
                base.Hit(hitValue);
                _lastDamageOnArmor = false;
            }
        }
	}
}