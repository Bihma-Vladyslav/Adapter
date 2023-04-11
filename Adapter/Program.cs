using System;

namespace Adapter
{
    // Адаптований інтерфейс, що використовується клієнтом
    interface ITextDocument
    {
        void Open();
        void Close();
        void SaveAsTxt(string filename);
    }

    // Адаптований клас, який має неправильний інтерфейс
    class WordDocument
    {
        private string filename;

        public WordDocument(string filename)
        {
            this.filename = filename;
        }

        public void Open()
        {
            Console.WriteLine("Opening Word document: " + filename);
        }

        public void Close()
        {
            Console.WriteLine("Closing Word document: " + filename);
        }

        public void SaveAsWord(string filename)
        {
            Console.WriteLine("Saving Word document: " + filename);
        }
    }

    class WordDocumentAdapter : ITextDocument
    {
        private WordDocument wordDocument;

        public WordDocumentAdapter(string filename)
        {
            this.wordDocument = new WordDocument(filename);
        }

        public void Open()
        {
            wordDocument.Open();
        }

        public void Close()
        {
            wordDocument.Close();
        }

        public void SaveAsTxt(string filename)
        {
            // Збереження у форматі txt, використовуючи адаптований клас WordDocument
            Console.WriteLine("Saving Word document as txt: " + filename);
        }
    }

    class ExcelDocument
    {
        private string filename;

        public ExcelDocument(string filename)
        {
            this.filename = filename;
        }

        public void Open()
        {
            Console.WriteLine("Opening Excel document: " + filename);
        }

        public void Close()
        {
            Console.WriteLine("Closing Excel document: " + filename);
        }

        public void SaveAsExcel(string filename)
        {
            Console.WriteLine("Saving Excel document: " + filename);
        }
    }

    class ExcelDocumentAdapter : ITextDocument
    {
        private ExcelDocument excelDocument;

        public ExcelDocumentAdapter(string filename)
        {
            this.excelDocument = new ExcelDocument(filename);
        }

        public void Open()
        {
            excelDocument.Open();
        }

        public void Close()
        {
            excelDocument.Close();
        }

        public void SaveAsTxt(string filename)
        {
            // Збереження у форматі txt, використовуючи адаптований клас ExcelDocument
            Console.WriteLine("Saving Excel document as txt: " + filename);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Робота з документом Word у форматі txt через адаптер
            ITextDocument doc1 = new WordDocumentAdapter("document.docx");
            doc1.Open();
            doc1.SaveAsTxt("document.txt");
            doc1.Close();

            Console.WriteLine();

            // Робота з документом Excel у форматі txt через адаптер
            ITextDocument doc2 = new ExcelDocumentAdapter("document.xlsx");
            doc2.Open();
            doc2.SaveAsTxt("document.txt");
            doc2.Close();

            Console.ReadLine();
        }
    }
}
