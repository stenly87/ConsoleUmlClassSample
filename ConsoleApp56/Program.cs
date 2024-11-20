
namespace ConsoleApp56
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer computer_I7 = new Computer_i7();
            computer_I7.Monitor = new Monitor();// ассоциация
            computer_I7.PrintInfo();
            Console.WriteLine(new string('#', 30));
            IUSB disk = new DiskExternal { Title = "Kingston 16GB" };
            computer_I7.USBDevice = disk; // ассоциация
            computer_I7.PrintInfo();
            Console.WriteLine(new string('#', 30));
            IUSB pot = new CoffePot { Title = "USB нагреватель кружки для кофе" };
            computer_I7.USBDevice = pot; // ассоциация
            computer_I7.PrintInfo();
        }
    }

    internal abstract class Computer
    {
        protected CPU cpu;
        protected MotherBoard board;
        public Monitor Monitor { get; set; }
        public IUSB USBDevice { get; set; }

        internal void PrintInfo()
        {
            Console.WriteLine($"Board: {board.Title}");
            Console.WriteLine($"CPU: {cpu.Title}");
            if (USBDevice != null)
                Console.WriteLine($"USBDevice: {USBDevice.Title}");
        }
    }

    internal interface IUSB
    {
        string Title { get; set; }
    }

    internal class DiskExternal : IUSB
    {
        public string Title { get; set; }
    }

    internal class CoffePot : IUSB
    {
        public string Title { get; set; }
    }

    internal class Monitor
    {
        public string Title { get; set; }
    }

    internal class Computer_i7 : Computer
    {
        public Computer_i7()
        {// агрегация
            board = new MotherBoardAsus("B560 M");
            cpu = new CPUIntel("i7 10700k");
        }
    }

    internal class ComputerComposite : Computer
    {
        public ComputerComposite(MotherBoard board,
            CPU cpu)
        {// композиция
            this.board = board;
            this.cpu = cpu;
        }
    }

    internal abstract class MotherBoard
    {
        public string Title { get; set; }
    }

    internal class MotherBoardAsus : MotherBoard
    {
        public MotherBoardAsus(string title)
        {
            Title = title;
        }
    }

    internal abstract class CPU
    {
        public string Title { get; set; }
    }

    internal class CPUIntel : CPU
    {
        public CPUIntel(string title)
        {
            Title = title;
        }
    }
}
