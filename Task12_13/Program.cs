using Task12_13.Models;

namespace Task12_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon weapon = new Weapon(30,20,30,true);
            bool breakpoint = true;
            do
            {
                Console.WriteLine("\n1 - İnformasiya al\n2 - Shoot\n3 - Fire\n4 - Lazim olan gulle sayi\n5 - Reload\n6 - Modu deyish\n7 - Proqramdan dayandır");
                Console.Write("Qisa yolu daxil edin: ");
                byte.TryParse(Console.ReadLine(), out byte key);
                switch (key)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(weapon.GetInfo());
                        break;
                    case 2:
                        Console.Clear();
                        weapon.Shoot();
                        break;
                    case 3:
                        Console.Clear();
                        weapon.Fire();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Daragi doldurmaq ucun lazim olan gulle sayi: {weapon.GetRemainBulletCount()}");
                        break;
                    case 5:
                        Console.Clear();
                        weapon.Reload();
                        break;
                    case 6:
                        Console.Clear();
                        weapon.ChangeFireMode();
                        break;
                    case 7:
                        Console.Clear();
                        breakpoint = false;
                        Console.WriteLine("Chixish edildi");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Yanlish qisayol daxil edilib!");
                        break;
                }
            } while (breakpoint);
        }

        
    }
}