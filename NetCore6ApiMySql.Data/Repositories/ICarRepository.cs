﻿using NetCore6ApiMySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6ApiMySql.Data.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> GetDetails(int id);

        Task<bool> InsertCar(Car car);
        Task<bool> UpdateCar(Car car);
        Task<bool> DeleteCar(Car car);

    }
}
