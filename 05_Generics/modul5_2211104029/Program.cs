public class SimpleDataBase<T>
{
    private List<T> storedData = new List<T>();
    private List<DateTime> inputDates = new List<DateTime>();

    public void AddNewData(T data)
    {
        storedData.Add(data);
        inputDates.Add(DateTime.UtcNow);
    }

    public void PrintAllData()
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, disimpan pada waktu UTC: {inputDates[i]}");
        }
    }
}

class Program
{
    static void Main()
    {
        SimpleDataBase<double> db = new SimpleDataBase<double>();
        db.AddNewData(22.0);
        db.AddNewData(11.0);
        db.AddNewData(10.0);
        db.PrintAllData();
    }
}