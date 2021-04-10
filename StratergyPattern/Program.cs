using System;


// 스트레티지 패턴(전략패턴)
// 여러 알고리즘을 하나의 추상적인 접근점을 만들어 접근 점에서 서로 교환 가능하도록 하는 패턴
// ref : https://www.youtube.com/watch?v=UEjsbd3IZvA&list=PLsoscMhnRc7pPsRHmgN4M8tqUdWZzkpxY
// 구현 예 : 무기교환 ( 칼, 총 )


namespace StratergyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCharacter character = new GameCharacter();

            character.attack();

            character.setWeapon(new Knife());
            character.attack();


            character.setWeapon(new Sword());
            character.attack();


            character.setWeapon(new Ax());
            character.attack();



        }


        // 선언과 기능을 분리 시킨다.
        public interface IAinterface
        {
            public void funcA();
        }

        public class AinterfaceImpl : IAinterface
        {
            void IAinterface.funcA()
            {
                Console.WriteLine("AAA");
            }
        }

        public class AObj
        {
            // 위임으로 사용.
            // : 객체의 기능을 사용한다.
            IAinterface ainterface;

            public AObj()
            {
                ainterface = new AinterfaceImpl();
            }

            public void funcAA()
            {
                ainterface.funcA();
                ainterface.funcA();
            }
        }



        // 무기 접합점(추상적인 접근점)
        public interface IWeapon
        {
            public void attack();
        }



        // 교환 가능한 무기1
        public class Knife : IWeapon
        {
            public void attack()
            {
                Console.WriteLine("칼 공격");
            }
        }

        // 교환 가능한 무기2
        public class Sword : IWeapon
        {
            public void attack()
            {
                Console.WriteLine("검 공격");
            }
        }

        // 추가한 무기
        public class Ax : IWeapon
        {
            public void attack()
            {
                Console.WriteLine("도끼 공격");
            }
        }


        public class GameCharacter
        {
            //접근점
            private IWeapon weapon;

            //교환가능
            public void setWeapon(IWeapon weapon)
            {
                this.weapon = weapon;
            }


            public void attack()
            {
                if (weapon == null)
                {
                    Console.WriteLine("맨손 공격");
                }
                else
                {

                    //델리게이트
                    weapon.attack();
                }
            }

        }
    }
}
