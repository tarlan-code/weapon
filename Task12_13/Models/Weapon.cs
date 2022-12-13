using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_13.Models
{
    internal class Weapon
    {
        byte _bulletCapacity;
        byte _bulletCount;
        float _bulletEmptyTime;
        bool _isMode;
      

        public byte BulletCapacity { 
            get => _bulletCapacity;
            set
            {
                if (_bulletCapacity>255) _bulletCapacity = 255;

                else _bulletCapacity = value;
            } 
        }

        public byte BulletCount {
            get => _bulletCount;
            set
            {
                if (value>BulletCapacity) _bulletCount = BulletCapacity;
                
                else _bulletCount = value;
            } 
        }

        public float BulletEmptyTime
        {
            get => _bulletEmptyTime;
            set
            {
                if (_bulletEmptyTime<0) _bulletEmptyTime = 1;
                
                else _bulletEmptyTime = value;
                
            }
        }

        public bool IsMode
        {
            get => _isMode;
            set
            {
                _isMode = value;
            }
        }

        public Weapon(byte bulletCapacity, byte bulletCount, byte bulletEmptyTime, bool isMode)
        {
            BulletCapacity = bulletCapacity;
            BulletCount = bulletCount;
            BulletEmptyTime = bulletEmptyTime;
            IsMode = isMode;
        }

        public void Shoot()
        {
            
            if (BulletCount > 0)
            {
                Console.WriteLine("1 eded gulle atesh edildi");
                BulletCount--;
            }

            else
            {
                Console.WriteLine("Daraqda gulle qalmayib");
                IsReload();
            }
            
            
        }

        public void Fire()
        {
            if (IsMode)
            {
                if (BulletCount >0)
                {
                    Console.WriteLine($"Butun gulleler ateslendi  Vaxt: {GetTime1Bullet()*BulletCount}");
                    BulletCount = 0;
                }

                else
                {
                    Console.WriteLine("Daraqda gulle qalmayib");
                    IsReload();
                }
            }

            else
            {
                Console.WriteLine("\nSilah tekli moddadi");
                Shoot();
            }
            
        }

        public byte GetRemainBulletCount()
        {

            return (byte)(BulletCapacity - BulletCount);
        }

        public void Reload()
        {
            Console.WriteLine("Daraq dolduruldu");
            BulletCount = BulletCapacity;
        }

        public void ChangeFireMode()
        {
            if (IsMode)
            {
                IsMode = false;
                Console.WriteLine($"Mod {GetMode()}-a deyisdirildi");
            }

            else
            {
                IsMode = true;
                Console.WriteLine($"Mod {GetMode()}-e deyisdirildi");
            }
        }


        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Gulle tutumu: {BulletCapacity} \n");
            sb.Append($"Gulle sayi: {BulletCount} \n");
           
            sb.Append($"Mod: {GetMode()} \n");

            return sb.ToString();

        }


        string GetMode()
        {
            if (IsMode) return "Avtomatik";
            else return "Tekli atish";

        }


        float GetTime1Bullet()
        {
            return (BulletCapacity / BulletEmptyTime);
        }

        void IsReload()
        {
            Console.WriteLine("Reload etmek isteyirsiz?(he/yox): ");
            string keyword = Console.ReadLine().Trim().ToLower();
            switch (keyword)
            {
                case "he":
                    Reload();
                    break;
                case "yox":
                    break;
                default:
                    Console.WriteLine("Yanlish komanda daxil edildi Reload etmek uchun -5- qisa yolundan istifade edin");
                    break;
            }
        }
    }
}
