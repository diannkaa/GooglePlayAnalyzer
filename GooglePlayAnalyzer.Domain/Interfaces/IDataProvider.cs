using GooglePlayAnalyzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlayAnalyzer.Domain.Interfaces
{
    public interface IDataProvider<T>
    {
        List<T> Load(string path);
        void Write(string path, List<T> data);
        bool ValidateFile(string path);
        string GetFileInfo(string path);
    }
}
