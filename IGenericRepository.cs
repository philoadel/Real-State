﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IGenericRepository <T>
    {
        IEnumerable<T> GetAll ();   
        T GetById (int id);
        void Add (T entity);
       void Update (T entity);
       void Delete (T entity);
    }
}
