using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Interfaces;

using EduHub.Ch02.Domain;

public interface IClubRepository
{
    void Add(Club club);
    Club? GetById(Guid id);
    IReadOnlyList<Club> GetAll();
}