using System;
using System.IO;
using System.Text;
internal class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int[] mass = new int[20];
        for (int i = 0; i < mass.Length; i++)
        {
            mass[i] = rnd.Next(-100, 100);
        }
        DirectoryInfo directory = new DirectoryInfo(@"D:\laba2");
        directory.Create();
        FileInfo file = new FileInfo(@"D:\laba2\1.txt");
        FileStream fs = file.Create();
        using (StreamWriter sw = new StreamWriter(fs))
        {
            for (int i = 0; i < mass.Length; i++)
            {
                sw.WriteLine(mass[i]);
            }
        }
        int cout = 0;
        int[] mass1 = new int[20];
        using (FileStream readOnlyStream = File.OpenRead(@"D:\laba2\1.txt"))
        {
            foreach (string animal in File.ReadAllLines(@"D:\laba2\1.txt"))
            {

                mass1[cout] = int.Parse(animal);
                cout++;
            }
        }
        double max = mass1[0];
        for (int i = 0; i < mass.Length; i++)
        { 
            if (max < mass1[i])
            {
                max = mass1[i];
            }
        }

        FileInfo file1 = new FileInfo(@"D:\laba2\2.txt");
        FileStream fs1 = file1.Create();
        int count = 0;
        using (StreamWriter sw = new StreamWriter(fs1))
        {
            for (int i = 0; i < mass1.Length; i++)
            {
                if (mass1[i] < 0)
                {
                    count++;
                    if (count%2==0)
                    {
                        sw.WriteLine(max/2);
                    }
                    else
                    {
                        sw.WriteLine(mass1[i]);
                    }
                }
                else    
                {
                    sw.WriteLine(mass1[i]);
                }
            }
        }
    }
}
