using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Provodnik
{
    public static class Provodnik
    {
        public static ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        public static List<string> dirs; 
        public static List<string> files; 
        private static DriveInfo[] allDrives = DriveInfo.GetDrives();

        private static DirectoryInfo dir;
        private static FileInfo fl;
        static public string path = "";

        static public int pointerPosistion = 1;

        static public void ChooseDrive()
        {
            path = "";
            Console.Clear();
         
            Console.WriteLine("Выбор диска:");
            Console.WriteLine("------------");
            foreach (var item in allDrives)
            {
                Console.WriteLine($"  {item.Name}");
            }

        }
        static public void OpenDrive()
        {
            path = allDrives[pointerPosistion - 2].Name;
            ShowDirectoryContents();
        }
        static public void OpenDirectory()
        {
            for (int i = 0; i < dirs.Count; i++)
            {
                if (i == pointerPosistion - 1)
                {
                    Console.Clear();

                    path = dirs[i - 1];
                    ShowDirectoryContents();
                    break;
                }
            }
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref pointerPosistion);
        }
        static public void OpenFile()
        {
            Process.Start(new ProcessStartInfo(files[pointerPosistion - 2]) { UseShellExecute = true });
        }
        static public void ReturnToBack()
        {
            string[] chastyPath = path.Split('\\');
            path = @"";
            for (int i = 0; i < chastyPath.Length - 1; i++)
            {
                path += chastyPath[i];
                path += '\\';
            }
            if (chastyPath.Length != 2) path = path.TrimEnd('\\');
            if (path.Length == 3) ChooseDrive();
            else ShowDirectoryContents();
            Arrow ar = new Arrow();
            ar.SetCursorToStart(ref pointerPosistion);
        }



        static public void ShowDirectoryContents()
        {
            Console.Clear();
            Console.WriteLine(path);
            Console.WriteLine("  Имя" + '\t' + '\t' + '\t' + '\t' +
               "|Дата изменения" + '\t' + '\t' + '\t' + '\t' +
               "  |Тип" + '\t' + '\t' +
               "|Размер   |");
            dirs = new List<string>(Directory.EnumerateDirectories(path));
            files = new List<string>(Directory.EnumerateFiles(path));
            string Title;
            foreach (var item in dirs)
            {
                dir = new DirectoryInfo(item);
                Title = dir.Name;
                if (Title.Length > 32)
                {
                    Title = Title.Substring(0, 29);
                    Title += "...";
                }
                Console.WriteLine("  {0,31}{1,21}{2,30}", Title, dir.LastWriteTime, dir.Attributes);
            }

            foreach (var item in files)
            {
                fl = new FileInfo(item);
                Title = fl.Name;
                if (Title.Length > 32)
                {
                    Title = Title.Substring(0, 29);
                    Title += "...";
                }

                Console.WriteLine("  {0,31}{1,21}{2,30}{3,15}", Title, fl.LastWriteTime, fl.Extension, fl.Length);

            }
            Console.SetCursorPosition(0, 0);
        }
    }
}
