class DataGeneric<T>
{
    private T data;
    public DataGeneric(T data)
    {
        this.data = data;
    }
    public void PrintData()
    {
        Console.WriteLine($"Data yang tersimpan adalah: {data}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        DataGeneric<string> data = new DataGeneric<string>("2211104029");
        data.PrintData();
    }
}