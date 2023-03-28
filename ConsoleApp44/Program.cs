using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp44
{
    // интерфейс боевой единицы
    public interface IMilitaryUnit
    {
        void Show(Point position);
    }

    // класс, представляющий легкую пехоту
    public class LightInfantry : IMilitaryUnit
    {
        private static Image image = LoadImage("light_infantry.png"); // картинка для отображения
        private static int speed = 20; // скорость перемещения
        private static int power = 10; // коэффициент силы

        public void Show(Point position)
        {
            // отрисовка картинки на позиции position с использованием статических полей speed и power
        }
    }

    // класс, представляющий транспортную автомашину
    public class TransportVehicle : IMilitaryUnit
    {
        private static Image image = LoadImage("transport_vehicle.png");
        private static int speed = 70;
        private static int power = 0;

        public void Show(Point position)
        {
            // отрисовка картинки на позиции position с использованием статических полей speed и power
        }
    }

    // класс, представляющий тяжелую наземную боевую технику
    public class HeavyGroundCombatVehicle : IMilitaryUnit
    {
        private static Image image = LoadImage("heavy_ground_combat_vehicle.png");
        private static int speed = 15;
        private static int power = 150;

        public void Show(Point position)
        {
            // отрисовка картинки на позиции position с использованием статических полей speed и power
        }
    }

    // класс, представляющий легкую наземную боевую технику
    public class LightGroundCombatVehicle : IMilitaryUnit
    {
        private static Image image = LoadImage("light_ground_combat_vehicle.png");
        private static int speed = 50;
        private static int power = 30;

        public void Show(Point position)
        {
            // отрисовка картинки на позиции position с использованием статических полей speed и power
        }
    }

    // класс, представляющий авиатехнику
    public class Aviation : IMilitaryUnit
    {
        private static Image image = LoadImage("aviation.png");
        private static int speed = 300;
        private static int power = 100;

        public void Show(Point position)
        {
            // отрисовка картинки на позиции position с использованием статических полей speed и power
        }
    }

    // класс, реализующий фабрику боевых единиц
    public class MilitaryUnitFactory
    {
        private Dictionary<string, IMilitaryUnit> units = new Dictionary<string, IMilitaryUnit>();

        public IMilitaryUnit GetMilitaryUnit(string type)
        {
            IMilitaryUnit unit;
            if (units.ContainsKey(type))
            {
                unit = units[type];
            }
            else
            {
                switch (type)
                {
                    case "LightInfantry":
                        unit = new LightInfantry();
                        break;
                    case "TransportVehicle":
                        unit = new TransportVehicle();
                        break;
                    case "HeavyGroundCombatVehicle":
                        unit = new HeavyGroundCombatVehicle();
                        break;
                    case "LightGroundCombatVehicle":
                        unit = new LightGroundCombatVehicle();
                        break;
                    case "Aviation":
                        unit = new Aviation();
                        break;
                    default:
                        throw new ArgumentException($"Invalid type: {type}");
                }
                units.Add(type, unit);
            }
            return unit;
        }
    }
    public class MilitaryBase
    {
        private MilitaryUnitFactory unitFactory = new MilitaryUnitFactory();
        private List<Tuple<string, Point>> units = new List<Tuple<string, Point>>();
        public void AddUnit(string type, Point position)
        {
            units.Add(Tuple.Create(type, position));
        }

        public void ShowAllUnits()
        {
            foreach (var unit in units)
            {
                IMilitaryUnit militaryUnit = unitFactory.GetMilitaryUnit(unit.Item1);
                militaryUnit.Show(unit.Item2);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var militaryBase = new MilitaryBase();
            militaryBase.AddUnit("LightInfantry", new Point(10, 10));
            militaryBase.AddUnit("TransportVehicle", new Point(20, 20));
            militaryBase.AddUnit("HeavyGroundCombatVehicle", new Point(30, 30));
            militaryBase.AddUnit("LightGroundCombatVehicle", new Point(40, 40));
            militaryBase.AddUnit("Aviation", new Point(50, 50));
            militaryBase.ShowAllUnits();
        }
    }
}

