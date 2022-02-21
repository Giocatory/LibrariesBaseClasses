namespace MultithreadingAsynchronousParallelism
{
    public delegate int BinaryOp(int x, int y);
    internal class SyncExe
    {
        public void ShowWork()
        {
            // Выполнение программы в 1 потоке, синхронно
            // Program execution in 1 thread, synchronously

            Console.WriteLine($"Main() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            // call Add() in synchronous mode (sync)
            BinaryOp b = new(Add);
            int answer = b.Invoke(10, 10);
            // Эти строки кода не выполнятся до тех пор, пока не завершится метод Add().
            // These lines of code will not be executed until the Add() method completes.
            Console.WriteLine("Doing more work in Main()");
            Console.WriteLine($"10 + 10 = {answer}");
        }
        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}.");
            Thread.Sleep(5000);
            return x + y;
        }
    }
}
