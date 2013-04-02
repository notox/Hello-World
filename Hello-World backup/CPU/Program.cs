using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Cpu c1 = new Cpu();
        c1.fun();
        Cpu c2 = new IntelCpu();
        c2.fun();
        Cpu c3 = new CoreCpu();
        c3.fun();
        IntelCpu c4 = new CoreCpu();
        c4.fun();

        Type t1 = c1.GetType();
        Type t2 = c2.GetType();
        Type t3 = c3.GetType();
        Type t4 = c4.GetType();
    }
}

class Cpu
{
    public Cpu()
    {
        Console.WriteLine("初始化Cpu");
    }
    public virtual void fun()
    {
        Console.WriteLine("Cpu的方法\n");
    }
}

class IntelCpu : Cpu
{
    public IntelCpu()
    {
        Console.WriteLine("初始化IntelCpu");
    }
    public override void fun()
    {
        Console.WriteLine("IntelCpu的方法\n");
    }
}

class CoreCpu : IntelCpu
{
    public CoreCpu()
    {
        Console.WriteLine("初始化CoreCpu");
    }
    public new void fun()
    {
        Console.WriteLine("CoreCpu的方法\n");
    }
}