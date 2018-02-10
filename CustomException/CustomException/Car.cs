using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    //Специальное исключение описывает детали условия входа автомобиля из строя
    public class CarIsDeadException : ApplicationException
    {
        private string messageDetails = String.Empty;
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        public CarIsDeadException(string message, string cause, DateTime time)
        {
            messageDetails = message;
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }
        //Переопределение свойства Exception.Message
        public override string Message
        {
            get
            {
                return string.Format("Car Error Message: {0}", messageDetails);
            }
        }
    }
    class Car
    {
        //Константа для представления макс скорости
        public const int MaxSpeed = 100;

        //Свойства автомобиля
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }

        //Проверка вышел ли из строя автомобиль
        private bool carIsDead;

        //Автомобиль имеет радиоприемник
        private Radio theMusicBox = new Radio();


        //Конструкторы
        public Car() { }
        public Car (string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes (bool state)
        {
            //Делегировать запрос внутреннему объекту 
            theMusicBox.TurnOn(state);
        }
        //Проверить, не перегрелся ли автомобиль (должно генерироваться исключение)
        public void Accelerate (int delta)
        {
            //    if (carIsDead)
            //    {
            //       Console.WriteLine("{0} is out of order...", PetName);
            //   }
            //   else
            //  {
            //  CurrentSpeed += delta;
            //  if ( CurrentSpeed >= MaxSpeed)
            //   {
            //      carIsDead = true;
            //      CurrentSpeed = 0;
            // Console.WriteLine("{0} has overheated!", PetName);
            //carIsDead = true;

            //Создать локальную переменную перед генерацией объекта Exception, чтобы можно было обращаться к свойству HelpLink
            //  Exception ex = new Exception(string.Format("{0}  has overheated!", PetName));
            //    ex.HelpLink = "http://www.CarsRUs.com";

            //Указать специальные данные, касающиеся ошибки
            // ex.Data.Add("TimeStamp", string.Format("The car exploaded at {0}", DateTime.Now));
            // ex.Data.Add("Cause", "You have a lead foot");


            CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has overheated!", PetName), "You have a lead foot", DateTime.Now);
            ex.HelpLink = "http://www.CarsRUs.com";
            throw ex;


                    // Использовать ключевое слово throw для генерации исключения
                    //throw new Exception(string.Format("{0} has overheated!", PetName));
               // }
              //  else
              //  {
             //       Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
              //  }
            }
        }
    }

