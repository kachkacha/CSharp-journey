using ConsoleApp1;
using static ConsoleApp1.Chapter4;

//var chapter = new Chapter4();
//chapter.Run();

var v = new Class2(new Class1("const init"));
Console.WriteLine(v.i);





class Class1
{
    public Class1(string s)
    {
        Console.WriteLine(s);
    }
}

class Class2
{
    public Class1 class1 { get; set; } = new Class1("field init");
    public int i = 1;

    //public Class2() { }

    public Class2(Class1 class1)
    {
        this.class1 = class1;
        i = 2;
    }
}