namespace TestNetFramework
{
    public class SavingsAccount
    {
        // Данные уровня экземпляра,
        public double currBalance;
        // Статический элемент данных.
        public static double currlnterestRate = 0.04;
        public SavingsAccount(double balance)
        {
            currBalance = balance;
        }
        // Статические члены для установки/получения процентной ставки,
        public static void SetlnterestRate(double newRate)
        { currlnterestRate = newRate; }
        public static double GetlnterestRate()
        { return currlnterestRate; }
    }

}
