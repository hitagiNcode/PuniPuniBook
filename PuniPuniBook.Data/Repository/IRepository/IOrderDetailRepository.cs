﻿using PuniPuniBook.Domain;

namespace PuniPuniBook.Data.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail obj);
    }
}
