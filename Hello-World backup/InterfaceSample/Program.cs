using System;

public interface MyInterface1
{
    void Method1();
    void Method2();
}
public interface MyInterface2
{
    void Method2();
    void Method3();
}

class MyClass : MyInterface1, MyInterface2
{
    public static string str = "MyString";
    public static uint ui = 0xAAAAAAAA;
    public void Method1() { Console.WriteLine("Method1"); }
    public void Method2() { Console.WriteLine("Method2"); }
    public virtual void Method3() { Console.WriteLine("Method3"); }
}

class Program
{
    static void Main()
    {
        MyClass mc = new MyClass();
        MyInterface1 mi1 = mc;
        MyInterface2 mi2 = mc;

        int i = MyClass.str.Length;
        uint j = MyClass.ui;

        mc.Method1();
        mi1.Method1();
        mi1.Method2();
        mi2.Method2();
        mi2.Method3();
        mc.Method3();

        mi1.Method2();
        mi2.Method2();
    }
}