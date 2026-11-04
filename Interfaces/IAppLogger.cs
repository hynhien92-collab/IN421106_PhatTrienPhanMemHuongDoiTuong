using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Interfaces;

public interface IAppLogger
{
    void Info(string message);
    void Error(string message);
}