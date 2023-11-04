using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    class DotAccess
    {
        class Foo
        {
            public Foo()
            {
                Child1 = new Bar();
            }

            int A = 0;
            string Str = "UUURRYYY!!!";

            public void I()
            {
                Console.Write("Hello_Foo!");
            }

            public Bar Child1;

            public class Bar
            {
                public Bar()
                {
                    Child2 = new Hoge();
                }

                double Pi = 3.1415;
                short Max = 64;

                public void J()
                {
                    Console.Write("Hello_Bar!");
                }

                public Hoge Child2;

                public class Hoge
                {
                    public Hoge()
                    {
                        Child3 = new Fuga();
                    }

                    long Min = -10000;
                    string Text = "Key";

                    public void M()
                    {
                        Console.Write("Hello_Hoge!");
                    }

                    public Fuga Child3;

                    public class Fuga
                    {
                        public Fuga()
                        {
                            Child4 = new Piyo();
                        }

                        float Milli = 0.001f;
                        bool IsDone = false;

                        public void L()
                        {
                            Console.Write("Hello_Fuga!");
                        }

                        public Piyo Child4;

                        public class Piyo
                        {
                            public void N()
                            {
                                Console.Write("Hello_Piyo!");
                            }
                        }
                    }
                }
            }
        }

        class Method1
        {
            public Method1(Foo foo, int count)
            {
                Foo = foo;
                Count = count;
            }

            Foo Foo;
            int Count;

            public void CallFoo()
            {
                for (int i = 0; i < Count; i++)
                    Foo.I();
                Console.Clear();
            }

            public void CallBar()
            {
                for (int i = 0; i < Count; i++)
                    Foo.Child1.J();
                Console.Clear();
            }

            public void CallHoge()
            {
                for (int i = 0; i < Count; i++)
                    Foo.Child1.Child2.M();
                Console.Clear();
            }

            public void CallFuga()
            {
                for (int i = 0; i < Count; i++)
                    Foo.Child1.Child2.Child3.L();
                Console.Clear();
            }

            public void CallPiyo()
            {
                for (int i = 0; i < Count; i++)
                    Foo.Child1.Child2.Child3.Child4.N();
                Console.Clear();
            }
        }

        class Method2
        {
            public Method2(Foo foo, int count)
            {
                Foo = foo;
                Bar = Foo.Child1;
                Hoge = Bar.Child2;
                Fuga = Hoge.Child3;
                Piyo = Fuga.Child4;
                Count = count;
            }

            Foo Foo;
            Foo.Bar Bar;
            Foo.Bar.Hoge Hoge;
            Foo.Bar.Hoge.Fuga Fuga;
            Foo.Bar.Hoge.Fuga.Piyo Piyo;
            int Count;

            public void CallFoo()
            {
                for (int i = 0; i < Count; i++)
                    Foo.I();
                Console.Clear();
            }

            public void CallBar()
            {
                for (int i = 0; i < Count; i++)
                    Bar.J();
                Console.Clear();
            }

            public void CallHoge()
            {
                for (int i = 0; i < Count; i++)
                    Hoge.M();
                Console.Clear();
            }

            public void CallFuga()
            {
                for (int i = 0; i < Count; i++)
                    Fuga.L();
                Console.Clear();
            }

            public void CallPiyo()
            {
                for (int i = 0; i < Count; i++)
                    Piyo.N();
                Console.Clear();
            }
        }

        public static void Entry()
        {
            int count1 = 1000;
            int count2 = 100;

            Foo foo = new Foo();
            Method1 m1 = new Method1(foo, count1);
            Method2 m2 = new Method2(foo, count1);

            TimeSpan m1foo = Program.Measure(count2, () => m1.CallFoo());
            TimeSpan m1bar = Program.Measure(count2, () => m1.CallBar());
            TimeSpan m1hoge = Program.Measure(count2, () => m1.CallHoge());
            TimeSpan m1fuga = Program.Measure(count2, () => m1.CallFuga());
            TimeSpan m1piyo = Program.Measure(count2, () => m1.CallPiyo());

            TimeSpan m2foo = Program.Measure(count2, () => m1.CallFoo());
            TimeSpan m2bar = Program.Measure(count2, () => m1.CallBar());
            TimeSpan m2hoge = Program.Measure(count2, () => m1.CallHoge());
            TimeSpan m2fuga = Program.Measure(count2, () => m1.CallFuga());
            TimeSpan m2piyo = Program.Measure(count2, () => m1.CallPiyo());

            Console.WriteLine($"{m1foo}\t{m1bar}\t{m1hoge}\t{m1fuga}\t{m1piyo}");
            Console.WriteLine($"{m2foo}\t{m2bar}\t{m2hoge}\t{m2fuga}\t{m2piyo}");
        }
    }
}
