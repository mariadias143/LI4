﻿using System;
using System.Collections.ObjectModel;
using System.Data;

namespace JARVIS.DataAccess
{
    public interface IDAO<T>
    {
        //insert new obj
        T Insert(T obj);
        //remove
        bool remove(string key);

        //FindById - o ID na nossa base de dados é uma tag de texto
        T FindById(string key);

        //FindByEmail
        T FindByEmail(string key);

        //Update data
        bool Update(string key, T obj);

        //ListAll
        Collection<T> ListAll();


    }
}
