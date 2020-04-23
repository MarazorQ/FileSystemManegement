using System;
using System.IO;
using System.IO.Compression;

namespace Client
{
    class Program
    {
         public static void DriveInf()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
            }

        }//1 +
         
         public static void HowManyFilesAndDirectory( string dirName)
        {
            //string dirName = "C:\\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }//2+

         public static void CreateDirectoris()
        {
            string path = @"C:\SomeDir";
            string subpath = @"program\avalon";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            dirInfo.CreateSubdirectory(subpath);
            Console.WriteLine("Каталог создан");
        }//3 ??? 

         public static void GetInfAboutDirectory(string dirName)//4+
        {
            //string dirName = "C:\\Program Files";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
        }

         public static void DeleteDirectory(string dirName)
        {
            //string dirName = @"C:\SomeFolder";

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);
                dirInfo.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }//5+

        public static void MoveDirctory(string oldPath, string newPath)
        {
           // string oldPath = @"C:\SomeFolder";
            //string newPath = @"C:\SomeDir";
            DirectoryInfo dirInfo = new DirectoryInfo(oldPath);
            if (dirInfo.Exists && Directory.Exists(newPath) == false)
            {
                dirInfo.MoveTo(newPath);
            }
        }//6+

         public static void GetInfAboutFiles(string path)
        {
            //string path = @"C:\SomeDir\1.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                Console.WriteLine("Имя файла: {0}", fileInf.Name);
                Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
                Console.WriteLine("Размер: {0}", fileInf.Length);
            }
        }//7++

         public static void DeleteFile(string path)
        {
            //string path = @"C:\SomeDir\1.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();
                // альтернатива с помощью класса File
                // File.Delete(path);
            }
        }//8++
         
         public static void MoveFile(string path,string newPath)
        {
           // string path = @"C:\apache\hta.txt";
            //string newPath = @"C:\SomeDir\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.MoveTo(newPath);
                // альтернатива с помощью класса File
                // File.Move(path, newPath);
            }
        }//9+

         public static void CopyFile(string path,string newPath)
        {
           // string path = @"C:\apache\hta.txt";
            //string newPath = @"C:\SomeDir\hta.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.CopyTo(newPath, true);
                // альтернатива с помощью класса File
                // File.Copy(path, newPath, true);
            }
        }//10+

         public static void CatFile(string path)
        {
            

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

         public static void CreateArchive(string sourceFile ,string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
                    }
                }
            }
        }

         public static void DeArchive(string compressedFile,string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
         
         public static void ClearCmd()
        {
             Console.Clear();
        
        }

         public static void Menu()
        {
            Console.WriteLine("1. Информация о дисках");
            Console.WriteLine("2. dir");
            Console.WriteLine("3. Создать подкаталога ");
            Console.WriteLine("4. Получить информацию о директории  ");
            Console.WriteLine("5. Удалить дерикторию");
            Console.WriteLine("6. Переместить каталог ");
            Console.WriteLine("7. Получить информацию о файле");
            Console.WriteLine("8. Удалить файл ");
            Console.WriteLine("9. Переместить файл ");
            Console.WriteLine("10.Копировать файл");
            Console.WriteLine("11.Ввывести содержимое файла ");
            Console.WriteLine("12.Создать архив");
            Console.WriteLine("13.Разархъивировать");
            Console.WriteLine("14.Оччистить консоль");

            Console.WriteLine("0. Выход");
        }

        static void Main(string[] args)
        {
            // System.Console.WriteLine(info());
            bool ShutDonw = true;
            while (ShutDonw){
                Menu();              
                int rezhim = Convert.ToInt32(Console.ReadLine());
                if (rezhim == 1)// case ?
                {
                    //
                    DriveInf();

                }

                else if (rezhim == 2)
                {
                    Console.WriteLine("Введите название диска в формате : C:\\");
                    string dirName = Console.ReadLine();
                    HowManyFilesAndDirectory(dirName);

                }
                else if (rezhim == 3)
                {
                    CreateDirectoris();
                }
                else if (rezhim == 0)
                {
                    ShutDonw = false;
                }

                else if (rezhim == 4)
                {
                    Console.WriteLine(" Введите путь(директорию в формате : С:\\Program Files");
                    string namedir = Console.ReadLine();
                    GetInfAboutDirectory(namedir);
                }
                else if (rezhim == 5)
                {
                    Console.WriteLine(" Введите название католога ,который хотите удалить в формате : D//Games");
                    string dir = Console.ReadLine();
                    DeleteDirectory(dir);
                }
                else if (rezhim == 6)
                {
                    Console.WriteLine("Введите путь откуда хотите переместить и  затем куда : из C:\\SomeFolder в C:\\SomeDir , но нужно учитывать , что каталог в который мы перемещаем не должен существовать");
                    string old = Console.ReadLine();
                    string newd = Console.ReadLine();
                    MoveDirctory(old,newd );
                }
                else if(rezhim == 7)
                {
                    Console.WriteLine("Введите путь к файлу в формате: C:\\SomeDir\\1.txt ");
                    string Path = Console.ReadLine();

                    GetInfAboutFiles(Path);
                }
                else if (rezhim == 8)
                {
                    Console.WriteLine("Введите путь к файлу в формате: C:\\SomeDir\\1.txt");
                    string pathh = Console.ReadLine();
                    DeleteFile(pathh);
                }
                else if (rezhim==9) {
                    Console.WriteLine("Введите путь откута хотите переместить файл и куда: из C:\\SomeDir\\1.txt  в C:\\SomeDir\\1\\1.txt ");
                    string oldput = Console.ReadLine();
                    string newput = Console.ReadLine();

                    MoveFile(oldput,newput);

                }
                else if (rezhim == 10)
                {
                    Console.WriteLine("Введите путь откута хотите скопировать файл и куда: из C:\\SomeDir\\1.txt  в C:\\SomeDir\\1\\1.txt  ");
                    string oldp = Console.ReadLine();
                    string newp = Console.ReadLine();
                    CopyFile(oldp,newp);
                }
                else if (rezhim == 11)
                {
                    string pa = Console.ReadLine();
                    CatFile(pa);
                }
                else if (rezhim == 12)
                {
                    Console.WriteLine(" Введите что сжимаем(путь) и куда сжимаем (алгоритм сжатия)");
                    string source = Console.ReadLine();
                    string compress = Console.ReadLine();
                    CreateArchive(source, compress);
                }
                else if (rezhim == 13)
                {
                    Console.WriteLine("Введите что хотите разархивировать(путь) и куда(название разархивированного файла и путь соответственно)");
                    string comres = Console.ReadLine();
                    string target = Console.ReadLine();
                    DeArchive(comres, target);
                }
                else if (rezhim == 14)
                {
                    ClearCmd();
                }

                else
                {
                    Console.WriteLine("Такой функции у нас нет, наверное вы ошиблись");
                }

            }
            Console.WriteLine("все)Вы завершили работу программы , приходите еще");

        }

    }
}