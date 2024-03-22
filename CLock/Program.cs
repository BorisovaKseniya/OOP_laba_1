

using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

class Clock
{
    static StringBuilder sb = new StringBuilder();
    static void Main(string[] args)
    {
        Idatetime time_format_1 = new EuFormat();
        time_format_1 = new Decorator1(time_format_1);
        sb = time_format_1.GetDataTime();
        Console.WriteLine(sb.ToString());
        Console.WriteLine(sb.ToString());


        time_format_1 = new UsFormat();
        time_format_1 = new Decorator1(time_format_1);
        sb = time_format_1.GetDataTime();
        Console.WriteLine(sb.ToString());

        time_format_1 = new EuFormat();
        time_format_1 = new Decorator2(time_format_1);
        sb = time_format_1.GetDataTime();
        Console.WriteLine(sb.ToString());

    }
    public abstract class Idatetime
    {
        public abstract StringBuilder GetDataTime();

    }

    class EuFormat : Idatetime
    {
        public override StringBuilder GetDataTime()
        {
            CultureInfo format = new CultureInfo("en-US");
            DateTime now = DateTime.Now;
            sb.Append(now.ToString(format));
            return Clock.sb;


            //Console.WriteLine(now.ToString("d", new CultureInfo("en-EU")));
            //Console.WriteLine(now.ToString("hh:mm tt", new CultureInfo("en-EU")));
        }
    }
    private class UsFormat : Idatetime
    {
        public override StringBuilder GetDataTime()
        {
            CultureInfo format = new CultureInfo("ru-RU");
            DateTime now = DateTime.Now;
            sb.Append(now.ToString(format));
            return Clock.sb;

            //Console.WriteLine(now.ToString("d", new CultureInfo("ru-RU")));
            //Console.WriteLine(now.ToString("hh:mm tt", new CultureInfo("ru-RU")));
        }
    }
    abstract class decorator : Idatetime
    {
        protected Idatetime dataformate;
        public decorator(Idatetime dataformate)
        {
            this.dataformate = dataformate;
        }

        public abstract void printim();
       
    }

    class Decorator1 : decorator
    {
        public Decorator1(Idatetime dataformt) : base(dataformt)
        {
        }
       
        
        public override void printim()
        {
            sb.Append("  a  ");
        }

        public override StringBuilder GetDataTime()
        {

            dataformate.GetDataTime();
            printim();
            return sb;
        }

    }
    class Decorator2 : decorator   // переделать как декоратор 1
    {
        public Decorator2(Idatetime dataformt) : base(dataformt)
        {
        }

        public override void printim()
        {
            sb.Append("  b  ");
        }

        public override StringBuilder GetDataTime()
        {

            dataformate.GetDataTime();
            printim();
            return sb;

        }

    }
}

