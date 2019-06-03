<<<<<<< HEAD
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
        T FindById(int key);

        T FindByName(string key);
        //Update data
        bool Update(string key, T obj);

        //ListAll
        Collection<T> ListAll();
     


    }
}
=======
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
        T FindById(int key);

        T FindByName(string key);
        //Update data
        bool Update(string key, T obj);

        //ListAll
        Collection<T> ListAll();
     


    }
}
>>>>>>> 726f6e1fed68bbf5c36d05b3e60e13b394906930
