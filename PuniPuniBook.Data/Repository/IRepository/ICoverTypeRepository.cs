﻿using PuniPuniBook.Domain;

namespace PuniPuniBook.Data.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
    }
}
