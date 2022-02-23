using System;

namespace TestNetFramework
{
    internal class CarDelegate
    {   // Данные состояния,
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; } = 100;
        public string PetName { get; set; }
        // Исправен ли автомобиль?
        private bool carlsDead;

        public delegate void CarEngineHandler(string msgForCaller); //определяем тип
        private CarEngineHandler carEngineHandler;

        // Конструкторы класса,
        public CarDelegate() { }
        public CarDelegate(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        public void RegisterWithCarEngineHandler(CarEngineHandler ceh)
        {            
            carEngineHandler += ceh;          
        }
        public void UnRegisterWithCarEngineHandler(CarEngineHandler ceh)
        {
            carEngineHandler -= ceh;
        }
        public void ShowDelegatedMethods()
        {
            foreach (var v in carEngineHandler.GetInvocationList())
            {
                Console.WriteLine(v.Method);
                Console.WriteLine(new String('-', 25));
            }
        }

        public void Accelerate(int delta)
        {           
            // Если этот автомобиль сломан, то отправить сообщение об этом,
            if (carlsDead)
            {
                if (carEngineHandler != null)
                    carEngineHandler("Sorry, this car is dead...");
            }
            else
                CurrentSpeed += delta;
            // Автомобиль почти сломан?
           
            if ( ( (MaxSpeed - CurrentSpeed) <=10 && (MaxSpeed - CurrentSpeed) >=1)
            && carEngineHandler != null)
            {
                carEngineHandler("Careful buddy! Gonna blow!");
            }
            if (CurrentSpeed >= MaxSpeed)
                carlsDead = true;
            else
                Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
        }
        
    }
}
